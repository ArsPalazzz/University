using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float initialSpeed = 20f; // ��������� �������� ����
    public float decelerationRate = 2.0f; // �������� ���������� ����

    private float currentSpeed;
    private Rigidbody rb;

    // ����� ��� ��������� ������� �������� ����
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

        // ��������� ������� ����������� ���� ����� ������������ �����
        Destroy(gameObject, 5.0f);
    }

    void FixedUpdate()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= decelerationRate * Time.fixedDeltaTime; // ��������� �������� �� ��������
            currentSpeed = Mathf.Max(currentSpeed, 0); // ��������, ��� �������� �� ������ ����
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
        // ��� ������������ ���������� ����
        Debug.Log(collision.collider.name);
        Destroy(gameObject);
    }
}
