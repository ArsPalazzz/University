using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float initialSpeed = 20f; // Начальная скорость пули
    public float decelerationRate = 2.0f; // Скорость замедления пули

    private float currentSpeed;
    private Rigidbody rb;

    // Метод для получения текущей скорости пули
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    void Start()
    {
        currentSpeed = initialSpeed;
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * currentSpeed;
        }

        // Запускаем функцию уничтожения пули через определенное время
        Destroy(gameObject, 5.0f);
    }

    void FixedUpdate()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= decelerationRate * Time.fixedDeltaTime; // Уменьшаем скорость со временем
            currentSpeed = Mathf.Max(currentSpeed, 0); // Убедимся, что скорость не меньше нуля
            //Debug.Log("Speed: " + currentSpeed);

            if (rb != null)
            {
                rb.velocity = transform.forward * currentSpeed;
                //Debug.Log("Velocity: " + rb.velocity);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // При столкновении уничтожаем пулю
        Debug.Log(collision.collider.name);
        Destroy(gameObject);
    }
}
