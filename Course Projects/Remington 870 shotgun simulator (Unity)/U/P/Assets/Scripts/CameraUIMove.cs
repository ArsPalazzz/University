using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraUIMove : MonoBehaviour
{

    //public Camera mainCamera;
    public float moveSpeed = 2.0f; // �������� ����������� ������
    public float rotateSpeed = 2.0f; // �������� �������� ������
                                     //public Vector3 offset; // �������� �� ����, ����� ������ ������� ������
                                     //public Vector3 targetAngle; // ���� ���������� ������
    private bool isMoving = false;




    public GameObject modalInfo;
    public GameObject modalInfoText;

    Vector3 startPosition;
    Vector3 needPosition;
    private Transform targetObject;
    bool move = false;
    float speed = 0.07f;
    float offset = 0;
    Quaternion startRotation;
    Quaternion needRotaton;

    public void Start()
    {
        modalInfo.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (move)
        {
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            transform.rotation = Quaternion.Slerp(startRotation, needRotaton, offset);
            if (offset >= 1)
            {
                move = false;
                offset = 0;
            }
        }
    }

    public void MoveToDefault()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("DisassemblyLocation").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position;
            needRotaton = targetObject.transform.rotation;
            modalInfo.SetActive(false);
        }
    }
   

   

    public void MoveToDisasssemblyAim()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Aim Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(-0.42f, 0.02f, -0.15f);
            needRotaton = Quaternion.Euler(0f, 0f, 0f);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "������������ ��� ������� ��������� � ������������ ��� ��������";
        }
    }

    public void MoveToDisasssemblyBead()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Bead Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(-0.42f, 0.02f, -0.2f);
            needRotaton = Quaternion.Euler(0f, 0f, 0f);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "������ ��� ��������� �������� ��������, ������� ������� ��������� ������� ������ �� ����";
        }
    }

    public void MoveToDisasssemblyEjectionPort()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Ejection Port Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(-0.2f, 0.5f, 0.4f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "������������ �������������� �������� ��������� ����� �� ������ ����� ������� ��������";
        }
    }

    public void MoveToDisasssemblyForeEnd()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Fore-End Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.25f, 0.5f, 0f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "������������� ��� ��������� � ����������� ����������� ��������� ��� ��������, ����������� ������� � �������� ��� �������";
        }
    }

    public void MoveToDisasssemblyFrontSight()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Front Sight Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(-0.3f, 0.5f, 1.6f);
            needRotaton = Quaternion.Euler(63, -89, 70);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "�������� ���������� ����������, ���������� ������� �������� � ����, �������� � �������� ������� ����� ��� ������������ ����� ���������";
        }
    }

    public void MoveToDisasssemblyLoadingPort()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Loading Port Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.5f, 0f, 0.1f);
            needRotaton = Quaternion.Euler(0, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "��������� � ������ ����� ��������� �������, ����� ������� �������������� �������� �������� � ������� ��� ����������� ��������";
        }
    }

    public void MoveToDisasssemblyMuzzle()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Muzzle Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.25f, 0.8f, 0.9f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "�������� ����� ������, ����� ������� ���������� ����� ������ � ������ ����� ��� ��������, ��������� ����������� � ��������� ��������.";
        }
    }

    public void MoveToDisasssemblyReceiver()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Receiver Assembly Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.25f, 0.8f, 0.25f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "�������� ����� ������, � ������� ������������� ��������� ��� �������, ��������� �������� � �������, ����������� ���������������� � ���������� ��� ��������";
        }
    }

    public void MoveToDisasssemblySafetyLock()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Safety lock Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0f, 0.6f, 1.6f);
            needRotaton = Quaternion.Euler(63, -89, 70);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "��������, ������� ��������� ��������� ��������, ������������ ��������� ������������ ������ � ����������� ������������ ��� ������� ��� ���������";
        }
    }

    public void MoveToDisasssemblySafetyMechanism()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Safety Mechanism Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.25f, 0.5f, 0f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "����������, ������� ��������� �������� ����������� ��������� ��������, ������������ ��������� ������������ ������ � ����������� ������������ ��� ���������������� ������� �� �����";
        }
    }

    public void MoveToDisasssemblySightMount()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Sight Mount Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(-0.42f, 0.03f, -0.11f);
            needRotaton = Quaternion.Euler(0f, 0f, 0f);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "��������, ����������� ������� ��������� ���������� ��� ������������ ������ �� ������� ����� ������ ��� ��������� �������� �������� � ����������� ������������ ������������";
        }
    }

    public void MoveToDisasssemblySightProtector()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Sight Protector Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(-0.4f, 0.8f, 0.9f);
            needRotaton = Quaternion.Euler(93, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "�������� �������� ��� ����������, ������� ��������� ������� ����� ������ ������, ������������ ��������� ������� ������� ����������� � ����������� ������������ ��� �������������";
        }
    }

    public void MoveToDisasssemblyStock()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Stock Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0f, 0.5f, -0.4f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "������ ����� ������, ��������������� ��� ����� � ��������� ����� ������� ��� ������������� ������ � ����� ��� ���������� � ���������� ��������";
        }
    }

    public void MoveToDisasssemblyStopPlate()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Stop Plate Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(-0.1f, 0.4f, 1.3f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "����� ��������� ��������� �������� � ���������, �������������� �������� �������� �������� � ��������������� ��� ��������� �������� �� ����� ��������";
        }
    }

    public void MoveToDisasssemblySwivel()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Swivel Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(-0.1f, 0.4f, 1.55f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "��������� ��� ������ � ������������ �� ���������� ������������ � ������� �������� ��� ����������� �������� �������� � ������������ ������";
        }
    }

    public void MoveToDisasssemblyTrigger()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Trigger Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0f, 0.5f, 0.1f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "����� ���������� ���������, ������� �������� ������� ��� ������������� ��������. ��� ������� ����� ���������� ������������ ��������, ��� �������� � ����� �� ����������� ���� �������, �, � ����������, � ��������";
        }
    }

    public void MoveToDisasssemblyCartridge1()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Cartridge Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.1f, 0.5f, 0f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "����������� ������� ����������, ���������� � ���� �������, �����, ���� (� ������ �������) ��� ������ (� ������ ������), � ����� ������. ����� ��������� � �������, ������ ����� � ��������";
        }
    }

    public void MoveToDisasssemblyCartridge2()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Cartridge001 Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.1f, 0.5f, 0.01f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "����������� ������� ����������, ���������� � ���� �������, �����, ���� (� ������ �������) ��� ������ (� ������ ������), � ����� ������. ����� ��������� � �������, ������ ����� � ��������";
        }
    }

    public void MoveToDisasssemblyCartridge3()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Cartridge002 Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.1f, 0.5f, 0.02f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "����������� ������� ����������, ���������� � ���� �������, �����, ���� (� ������ �������) ��� ������ (� ������ ������), � ����� ������. ����� ��������� � �������, ������ ����� � ��������";
        }
    }

    public void MoveToDisasssemblyCartridge4()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Cartridge003 Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.1f, 0.5f, 0.03f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "����������� ������� ����������, ���������� � ���� �������, �����, ���� (� ������ �������) ��� ������ (� ������ ������), � ����� ������. ����� ��������� � �������, ������ ����� � ��������";
        }
    }

    public void MoveToDisasssemblyCartridge5()
    {
        if (!isMoving)
        {
            targetObject = GameObject.Find("Cartridge004 Disassembly").transform;

            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = targetObject.transform.position + new Vector3(0.1f, 0.5f, 0.04f);
            needRotaton = Quaternion.Euler(63, -89, 0);
            modalInfo.SetActive(true);
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "����������� ������� ����������, ���������� � ���� �������, �����, ���� (� ������ �������) ��� ������ (� ������ ������), � ����� ������. ����� ��������� � �������, ������ ����� � ��������";
        }
    }
}
