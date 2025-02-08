using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using System;

public class Click : MonoBehaviour, IPointerClickHandler
{
    public GameObject cube1;
    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick");
        //cube1.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0f, 1.0f));
        //new Color(Random.Range(0f, 1.0f), Random.Range(0f, 1.0f), Random.Range(0f, 1.0f))
        float red = Random.Range(.0f, 1.0f);
        float green = Random.Range(.0f, 1.0f);
        float blue = Random.Range(.0f, 1.0f);
        Color col1 = new Color(red, green, blue);

        Vector3 target = eventData.pointerPressRaycast.worldPosition;

        // Определяем направление удара
        Vector3 collid = Camera.main.transform.position;

        // Определяем силу удара
        int forse = 400;

        // Вычисляем вектор направления удара и нормализуем его
        Vector3 distance = (target - collid).normalized;

        // Умножаем вектор направления на силу удара
        collid = distance * forse;

        // Применяем удар к компоненте Rigidbody объекта
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(collid, target);

        // Задаем случайный цвет для игрового объекта
        gameObject.GetComponent<Renderer>().material.color = col1;
    }
}
