using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f; // Скорость ходьбы
    public float strafeSpeed = 3f; // Скорость бокового движения
    public float sensitivity = 2f; // Чувствительность мыши

    public ParticleSystem muzzleFlash;
    public Image crosshair;
    public TextMeshProUGUI cartridges;

    public float lookSpeed = 2f; // Скорость поворота камеры вверх и вниз
    public float maxLookAngle = 180f; // Максимальный угол поворота камеры вверх и вниз

    public float walkBobbingSpeed = 14f; // Скорость "потрясывания" при ходьбе
    public float walkBobbingAmount = 0.05f; // Амплитуда "потрясывания" при ходьбе

    private float defaultPosY;
    private float timer = 0.0f;

    public AudioSource footstepAudioSource; // Ссылка на AudioSource для звуков шагов
    private bool isMoving = false; // Флаг для отслеживания движения игрока

    private void Start()
    {
        defaultPosY = transform.localPosition.y;
        muzzleFlash.Stop();

        if (!GameManager.instance.isWeaponPicked)
        {
            crosshair.gameObject.SetActive(false);
            cartridges.gameObject.SetActive(false);
        }

    }

    private void Update()
    {

        if (GameManager.instance.currentScene != CurrentScene.ShootingRange) return;

        // Передвижение
        float horizontal = Input.GetAxis("Horizontal"); // Вправо/влево
        float vertical = Input.GetAxis("Vertical"); // Вперёд/назад

        Vector3 movement = new Vector3(horizontal * strafeSpeed, 0f, vertical * walkSpeed) * Time.deltaTime;

        isMoving = (horizontal != 0 || vertical != 0);

        // Включение или выключение звуков шагов в зависимости от движения игрока
        if (isMoving)
        {
            // Если игрок движется, включаем звуки шагов
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play();
            }
        }
        else
        {
            // Если игрок не движется, выключаем звуки шагов
            if (footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }
        }

        // Добавляем эффект "потрясывания" камеры при ходьбе
        if (movement.magnitude > 0)
        {
            timer += walkBobbingSpeed * Time.deltaTime;
            float bobbingAmount = Mathf.Sin(timer) * walkBobbingAmount;

            // Применяем вертикальное потрясывание камеры
            float newYPos = defaultPosY + bobbingAmount;
            transform.localPosition = new Vector3(transform.localPosition.x, newYPos, transform.localPosition.z);
        }
        else
        {
            // Возвращаем камеру к её исходной позиции
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY, transform.localPosition.z);
            timer = 0.0f;
        }

        transform.Translate(movement);

        // Поворот камеры влево и вправо
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(Vector3.up, mouseX);

        // Поворот камеры вверх и вниз
        float mouseY = -Input.GetAxis("Mouse Y") * sensitivity; // Умножаем на -1, чтобы инвертировать направление
        float newRotationX = transform.localEulerAngles.x + mouseY;
      
        transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, 0);
    }
}
