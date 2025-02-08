using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Euler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float rotationSpeedX = 50.0f; // Скорость вращения по оси X
    public float rotationSpeedZ = 30.0f; // Скорость вращения по оси Z

    private float currentRotationX = 0.0f; // Текущий угол вращения по оси X
    private float currentRotationZ = 0.0f; // Текущий угол вращения по оси Z

    void Update()
    {
        // Вычисляем новые углы вращения по осям X и Z на основе скоростей и времени между кадрами
        float rotationDeltaX = rotationSpeedX * Time.deltaTime;
        float rotationDeltaZ = rotationSpeedZ * Time.deltaTime;

        // Вращаем куб вокруг оси X и обновляем текущий угол
        transform.Rotate(Vector3.right, rotationDeltaX);
        currentRotationX += rotationDeltaX;

        // Вращаем куб вокруг оси Z, учитывая текущий угол вращения по оси X, чтобы сохранить последовательность поворотов
        transform.Rotate(Vector3.forward, rotationDeltaZ);
        currentRotationZ += rotationDeltaZ;

        // Если текущий угол вращения по оси X достиг 360 градусов, сбрасываем его
        if (currentRotationX >= 360.0f)
        {
            currentRotationX = 0.0f;
        }

        // Если текущий угол вращения по оси Z достиг 360 градусов, сбрасываем его
        if (currentRotationZ >= 360.0f)
        {
            currentRotationZ = 0.0f;
        }
    }
}
