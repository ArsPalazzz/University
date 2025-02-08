using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTriggerWeapon : MonoBehaviour
{
    public GameObject hintObject; // объект подсказки

    public void Start()
    {
        hintObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && GameManager.instance.isWeaponPicked != true) // проверяем, если в триггер вошел игрок
        {
            hintObject.SetActive(true); // активируем объект подсказки
        }
    }

   
}
