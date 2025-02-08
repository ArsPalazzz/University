using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Light pointLight;  // источник света, который нужно включать и выключать
    public Light spot1; // объект источник света
    public Light spot2; // объект источник света
    public Light spot3; // объект источник света
    public Light spot4; // объект источник света

    public Camera camera;

    void OnTriggerEnter(Collider col)
    {
        // проверяем, что в триггере находится персонаж с именем "player"
        if (col.gameObject.name == "player")
        {
            // включаем свет, если он выключен
            if (!pointLight.enabled)
            {
                pointLight.enabled = true;
                camera.transform.position += new Vector3(2, 0, 0);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        // проверяем, что из триггера вышел персонаж с именем "player"
        if (col.gameObject.name == "player")
        {
            // выключаем свет, если он включен
            if (pointLight.enabled)
            {
                pointLight.enabled = false;
                camera.transform.position -= new Vector3(2, 0, 0);
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.name == "player") // если персонаж в триггере
        {
            spot1.transform.Rotate(Vector3.up, 70 * Time.deltaTime); // вращаем источник света
            spot2.transform.Rotate(Vector3.up, 70 * Time.deltaTime); // вращаем источник света
            spot3.transform.Rotate(Vector3.up, 70 * Time.deltaTime); // вращаем источник света
            spot4.transform.Rotate(Vector3.up, 70 * Time.deltaTime); // вращаем источник света
           
        }
    }
}
