using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject doors;
    public Camera camera;

    void OnTriggerEnter(Collider col)
    {
        // проверяем, что в триггере находится персонаж с именем "player"
        if (col.name == "player")
        {
            doors.transform.position += new Vector3(0, 0, 2); // перемещаем источник света по оси z
            camera.transform.position += new Vector3(6, 0, 0);
        }
    }

    void OnTriggerExit(Collider col)
    {
        // проверяем, что из триггера вышел персонаж с именем "player"
        // выключаем свет, если он включен
        if (col.name == "player")
        {
            doors.transform.position -= new Vector3(0, 0, 2); // перемещаем источник света по оси z
            camera.transform.position -= new Vector3(6, 0, 0); // перемещаем источник света по оси z
        }
    }
}
