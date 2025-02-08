using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotTrigger : MonoBehaviour
{
    // Start is called before the first frame update
     public Light spot1; // объект источник света

    void OnTriggerStay(Collider col)
    {
        if (col.name == "player") // если персонаж в триггере
        {
            spot1.transform.Rotate(Vector3.up, 50 * Time.deltaTime); // вращаем источник света
        }
    }
}
