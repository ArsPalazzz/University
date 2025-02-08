using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float scaleSpeedX = 0.1f; // Скорость масштабирования по оси X

    void Update()
    {
        // Вычисляем приращение масштабирования по оси X на основе скорости и времени между кадрами
        float scaleX = scaleSpeedX * Time.deltaTime;

        // Создаем новый Vector3 с приращением масштабирования по оси X
        Vector3 newScale = transform.localScale + new Vector3(scaleX, scaleX, 0);

        // Применяем новый масштаб к объекту
        transform.localScale = newScale;
    }
}
