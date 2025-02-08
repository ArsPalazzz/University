using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float moveSpeed = 35f; // Скорость перемещения объекта

    void Update()
    {
        // Получаем значения осей перемещения по горизонтали и вертикали
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Создаем вектор направления перемещения
        Vector3 moveDirection = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;

        // Проверяем нажатие клавиш Q и E для перемещения по оси Z (вперед и назад)
        if (Input.GetKey(KeyCode.Q))
        {
            moveDirection += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            moveDirection += Vector3.back * moveSpeed * Time.deltaTime;
        }

        // Применяем перемещение к объекту
        transform.position += moveDirection;
    }
}
