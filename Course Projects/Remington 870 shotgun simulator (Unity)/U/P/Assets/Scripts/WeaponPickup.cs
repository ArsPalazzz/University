using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponPickup : MonoBehaviour
{
    public Transform playerCamera; // Ссылка на камеру игрока
    public float weaponRotationY = 90f; // Угол поворота оружия при подборе
    public float weaponDistance = 2f; // Расстояние от камеры до оружия при подборе

   

    private bool isWeaponPickedUp = false; // Подобрано ли оружие

    public AudioSource audioSource;

   

    void Update()
    {
        // Если нажата клавиша "E" и оружие еще не подобрано
        if (Input.GetKeyDown(KeyCode.E) && !isWeaponPickedUp && GameObject.Find("Pick up the weapon hint").activeSelf)
        {
            // Подбираем оружие
            PickupWeapon();
        }
    }

    void PickupWeapon()
    {
        // Изменяем состояние оружия
        isWeaponPickedUp = true;
        audioSource.Play();
        GameManager.instance.isWeaponPicked = true;

        GameObject.Find("Cube").GetComponent<SphereCollider>().enabled = false;
        GameObject.Find("Pick up the weapon hint").SetActive(false);
        // Получаем текущую позицию и направление камеры
        Vector3 cameraPosition = playerCamera.position;
        Vector3 cameraForward = playerCamera.forward;

        // Определяем позицию, к которой будет прикреплено оружие
        Vector3 weaponPosition = cameraPosition + cameraForward * weaponDistance * 5.0f + cameraForward;
       
        // Перемещаем оружие к этой позиции
        transform.position = weaponPosition;
        GameManager.instance.weaponMainPosition = weaponPosition;

        // Поворачиваем оружие так, чтобы оно смотрело в сторону камеры
        transform.rotation = Quaternion.LookRotation(playerCamera.forward);
        GameManager.instance.weaponMainRotation = Quaternion.LookRotation(playerCamera.forward);

        // Устанавливаем камеру в качестве родителя для оружия
        transform.parent = playerCamera.transform;

        // Сбрасываем локальное смещение и вращение оружия
        transform.localPosition = new Vector3(0.5f, -0.25f, 0.75f);
        transform.localRotation = Quaternion.Euler(-90.0f, 85.0f, 0);
    }
}
