using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Rotate : MonoBehaviour
{
    public float rotationSpeedY = 50.0f;
    public float currentRotationY = 0.0f; // Текущий угол вращения по оси Z
    // Start is called before the first frame update
    void Start()
    {
        RotateCube();
    }


    void RotateCube()
    {
        // Вращаем куб вокруг вертикальной оси Y с указанной скоростью
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime, Space.World);
    }
    
    // Update is called once per frame
    void Update()
    {
        float rotationDeltaY = rotationSpeedY * Time.deltaTime;

        transform.Rotate(Vector3.right, rotationDeltaY);
        currentRotationY += rotationDeltaY;

        if (currentRotationY >= 360.0f)
        {
            currentRotationY = 0.0f;
        }
    }
}
