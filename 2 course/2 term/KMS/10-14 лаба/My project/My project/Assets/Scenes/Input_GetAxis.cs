using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_GetAxis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float moveSpeed = 1f; // Скорость перемещения объекта
    public float rotationSpeed = 1f; // Скорость вращения объекта

    private float rotationX = 0f; // Угол вращения по вертикали

    void Update()
    {
        // Получаем значения осей перемещения по горизонтали и вглубь
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Получаем значения осей вращения по горизонтали и вертикали
        float rotationY = Input.GetAxis("Mouse X") * rotationSpeed;
        float rotationZ = -Input.GetAxis("Mouse Y") * rotationSpeed; // Инвертируем ось Y

        // Ограничиваем вращение объекта по вертикальной оси от 0 до 90 градусов
        rotationX += rotationZ;
        rotationX = Mathf.Clamp(rotationX, 0f, 90f);

        // Перемещаем объект по горизонтали и вглубь
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);

        // Вращаем объект по горизонтали и вертикали
        transform.Rotate(new Vector3(0, rotationY, 0));
        transform.Rotate(new Vector3(rotationX, 0, 0));
    }
}
