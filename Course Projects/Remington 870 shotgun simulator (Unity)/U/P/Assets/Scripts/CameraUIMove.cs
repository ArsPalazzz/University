using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraUIMove : MonoBehaviour
{

    //public Camera mainCamera;
    public float moveSpeed = 2.0f; // Скорость перемещения камеры
    public float rotateSpeed = 2.0f; // Скорость вращения камеры
                                     //public Vector3 offset; // Смещение от цели, чтобы задать позицию камеры
                                     //public Vector3 targetAngle; // Угол ориентации камеры
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Используется для точного наведения и прицеливания при стрельбе";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Служит для улучшения точности стрельбы, помогая стрелку правильно навести оружие на цель";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Обеспечивает автоматическое удаление стреляных гильз из оружия после каждого выстрела";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Предназначено для удержания и поддержания стабильного положения при стрельбе, обеспечивая комфорт и удобство для стрелка";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Переднее прицельное устройство, помогающее стрелку целиться в цель, выступая в качестве опорной точки для прицеливания перед выстрелом";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Отверстие в нижней части ствольной коробки, через которое осуществляется загрузка патронов в магазин для последующей стрельбы";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Передняя часть ствола, через которую происходит вылет гильзы и разлет дроби при выстреле, определяя направление и дальность стрельбы.";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Основная часть оружия, в которой располагаются механизмы для затвора, спусковой механизм и магазин, обеспечивая функциональность и надежность при стрельбе";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Механизм, который блокирует спусковой механизм, предотвращая случайное срабатывание оружия и обеспечивая безопасность при ношении или переноске";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Устройство, которое позволяет временно блокировать спусковой механизм, предотвращая случайное срабатывание оружия и обеспечивая безопасность при непреднамеренном нажатии на курок";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Механизм, позволяющий надежно закрепить оптический или механический прицел на верхней части ствола для улучшения точности стрельбы и обеспечения стабильности прицеливания";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Защитная оболочка или обтекатель, которая покрывает верхнюю часть ствола оружия, предотвращая случайное касание горячей поверхности и обеспечивая безопасность при использовании";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Задняя часть оружия, предназначенная для опоры и поддержки плеча стрелка при прикладывании оружия к плечу для комфортной и стабильной стрельбы";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Часть механизма крепления приклада к приемнику, обеспечивающая надежную фиксацию приклада и предотвращающая его случайное смещение во время стрельбы";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Соединяет два ствола и обеспечивает их правильное расположение и жесткую фиксацию для обеспечения точности стрельбы и устойчивости оружия";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Часть спускового механизма, которую нажимает стрелок для осуществления выстрела. При нажатии курка происходит освобождение ударника, что приводит к удару по внутреннему узлу затвора, и, в результате, к выстрелу";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Комплексная единица боеприпаса, содержащая в себе капсюль, порох, пулю (в случае картечи) или снаряд (в случае гильзы), а также гильзу. После заряжания в магазин, патрон готов к стрельбе";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Комплексная единица боеприпаса, содержащая в себе капсюль, порох, пулю (в случае картечи) или снаряд (в случае гильзы), а также гильзу. После заряжания в магазин, патрон готов к стрельбе";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Комплексная единица боеприпаса, содержащая в себе капсюль, порох, пулю (в случае картечи) или снаряд (в случае гильзы), а также гильзу. После заряжания в магазин, патрон готов к стрельбе";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Комплексная единица боеприпаса, содержащая в себе капсюль, порох, пулю (в случае картечи) или снаряд (в случае гильзы), а также гильзу. После заряжания в магазин, патрон готов к стрельбе";
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
            modalInfoText.GetComponent<TextMeshProUGUI>().text = "Комплексная единица боеприпаса, содержащая в себе капсюль, порох, пулю (в случае картечи) или снаряд (в случае гильзы), а также гильзу. После заряжания в магазин, патрон готов к стрельбе";
        }
    }
}
