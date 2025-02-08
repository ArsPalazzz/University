using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponPickup : MonoBehaviour
{
    public Transform playerCamera; // ������ �� ������ ������
    public float weaponRotationY = 90f; // ���� �������� ������ ��� �������
    public float weaponDistance = 2f; // ���������� �� ������ �� ������ ��� �������

   

    private bool isWeaponPickedUp = false; // ��������� �� ������

    public AudioSource audioSource;

   

    void Update()
    {
        // ���� ������ ������� "E" � ������ ��� �� ���������
        if (Input.GetKeyDown(KeyCode.E) && !isWeaponPickedUp && GameObject.Find("Pick up the weapon hint").activeSelf)
        {
            // ��������� ������
            PickupWeapon();
        }
    }

    void PickupWeapon()
    {
        // �������� ��������� ������
        isWeaponPickedUp = true;
        audioSource.Play();
        GameManager.instance.isWeaponPicked = true;

        GameObject.Find("Cube").GetComponent<SphereCollider>().enabled = false;
        GameObject.Find("Pick up the weapon hint").SetActive(false);
        // �������� ������� ������� � ����������� ������
        Vector3 cameraPosition = playerCamera.position;
        Vector3 cameraForward = playerCamera.forward;

        // ���������� �������, � ������� ����� ����������� ������
        Vector3 weaponPosition = cameraPosition + cameraForward * weaponDistance * 5.0f + cameraForward;
       
        // ���������� ������ � ���� �������
        transform.position = weaponPosition;
        GameManager.instance.weaponMainPosition = weaponPosition;

        // ������������ ������ ���, ����� ��� �������� � ������� ������
        transform.rotation = Quaternion.LookRotation(playerCamera.forward);
        GameManager.instance.weaponMainRotation = Quaternion.LookRotation(playerCamera.forward);

        // ������������� ������ � �������� �������� ��� ������
        transform.parent = playerCamera.transform;

        // ���������� ��������� �������� � �������� ������
        transform.localPosition = new Vector3(0.5f, -0.25f, 0.75f);
        transform.localRotation = Quaternion.Euler(-90.0f, 85.0f, 0);
    }
}
