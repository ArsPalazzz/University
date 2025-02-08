using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPosition : MonoBehaviour
{
    public float speed = 15.0f; // Скорость перемещения объекта
    public float speedY = 10.0f;
    public float speedZ = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
        {
            // Получаем текущую позицию объекта
            Vector3 currentPosition = transform.position;

            // Вычисляем новую позицию объекта на основе текущей позиции и скорости
            float newX = currentPosition.x + speed * Time.deltaTime;
            float newY = currentPosition.y + speedY * Time.deltaTime;
            float newZ = currentPosition.z + speedZ * Time.deltaTime;

            // Создаем новый вектор позиции с обновленным значением X
            Vector3 newPosition = new Vector3(newX, newY, newZ);

            // Применяем новую позицию объекту
            transform.position = newPosition;
        }
    }
}
