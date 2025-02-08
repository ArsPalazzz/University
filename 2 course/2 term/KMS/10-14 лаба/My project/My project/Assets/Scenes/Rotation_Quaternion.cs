using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Quaternion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public float rotationSpeedX = 50.0f; // Скорость вращения по оси X
     public float rotationSpeedZ = 30.0f; // Скорость вращения по оси Z

    void Update()
    {
        // Вычисляем новые углы вращения по осям X и Z на основе скоростей и времени между кадрами
        float rotationDeltaX = rotationSpeedX * Time.deltaTime;
        float rotationDeltaZ = rotationSpeedZ * Time.deltaTime;

        // Вращаем куб вокруг оси X
        transform.Rotate(Vector3.right, rotationDeltaX);

        // Вращаем куб вокруг оси Z
        transform.Rotate(Vector3.forward, rotationDeltaZ);
    }







    // public float rotationSpeedX = 50.0f; // Скорость вращения по оси X
    // public float rotationSpeedZ = 30.0f; // Скорость вращения по оси Z

    // private Quaternion initialRotation; // Начальный поворот объекта
    // private float totalRotationAngle; // Общий угол поворота объекта

    // void Start()
    // {
    //     // Фиксируем начальный поворот объекта
    //     initialRotation = transform.rotation;
    // }

    // void Update()
    // {
    //     // Вычисляем приращение угла поворота на основе скоростей и времени между кадрами
    //     float rotationDeltaX = rotationSpeedX * Time.deltaTime;
    //     float rotationDeltaZ = rotationSpeedZ * Time.deltaTime;

    //     // Вычисляем углы поворота вокруг осей X и Z последовательно
    //     float rotationAngleX = rotationDeltaX * Mathf.Rad2Deg;
    //     float rotationAngleZ = rotationDeltaZ * Mathf.Rad2Deg;

    //     // Задаем общий угол поворота объекта вокруг осей X и Z
    //     totalRotationAngle += rotationAngleX + rotationAngleZ;

    //     // Создаем новый Quaternion на основе начального поворота объекта и общего угла поворота
    //     Quaternion newRotation = initialRotation * Quaternion.Euler(rotationAngleX, 0, rotationAngleZ);

    //     // Применяем новый поворот объекту
    //     transform.rotation = newRotation;
    // }
}
