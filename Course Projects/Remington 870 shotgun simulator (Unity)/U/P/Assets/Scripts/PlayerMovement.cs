using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f; // �������� ������
    public float strafeSpeed = 3f; // �������� �������� ��������
    public float sensitivity = 2f; // ���������������� ����

    public ParticleSystem muzzleFlash;
    public Image crosshair;
    public TextMeshProUGUI cartridges;

    public float lookSpeed = 2f; // �������� �������� ������ ����� � ����
    public float maxLookAngle = 180f; // ������������ ���� �������� ������ ����� � ����

    public float walkBobbingSpeed = 14f; // �������� "������������" ��� ������
    public float walkBobbingAmount = 0.05f; // ��������� "������������" ��� ������

    private float defaultPosY;
    private float timer = 0.0f;

    public AudioSource footstepAudioSource; // ������ �� AudioSource ��� ������ �����
    private bool isMoving = false; // ���� ��� ������������ �������� ������

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

        // ������������
        float horizontal = Input.GetAxis("Horizontal"); // ������/�����
        float vertical = Input.GetAxis("Vertical"); // �����/�����

        Vector3 movement = new Vector3(horizontal * strafeSpeed, 0f, vertical * walkSpeed) * Time.deltaTime;

        isMoving = (horizontal != 0 || vertical != 0);

        // ��������� ��� ���������� ������ ����� � ����������� �� �������� ������
        if (isMoving)
        {
            // ���� ����� ��������, �������� ����� �����
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play();
            }
        }
        else
        {
            // ���� ����� �� ��������, ��������� ����� �����
            if (footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }
        }

        // ��������� ������ "������������" ������ ��� ������
        if (movement.magnitude > 0)
        {
            timer += walkBobbingSpeed * Time.deltaTime;
            float bobbingAmount = Mathf.Sin(timer) * walkBobbingAmount;

            // ��������� ������������ ������������ ������
            float newYPos = defaultPosY + bobbingAmount;
            transform.localPosition = new Vector3(transform.localPosition.x, newYPos, transform.localPosition.z);
        }
        else
        {
            // ���������� ������ � � �������� �������
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY, transform.localPosition.z);
            timer = 0.0f;
        }

        transform.Translate(movement);

        // ������� ������ ����� � ������
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(Vector3.up, mouseX);

        // ������� ������ ����� � ����
        float mouseY = -Input.GetAxis("Mouse Y") * sensitivity; // �������� �� -1, ����� ������������� �����������
        float newRotationX = transform.localEulerAngles.x + mouseY;
      
        transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, 0);
    }
}
