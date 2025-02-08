using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public float damping = 5f; // ����������� �������������

    void Update()
    {
        // �������� ������� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
           
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ��������, ��� �� ������ �� �������
            if (Physics.Raycast(ray, out hit))
            {
              
                if (hit.collider.gameObject == gameObject)
                {

                    // ���������� �������� �� ������� ������� �� ������� ����
                    offset = transform.position - hit.point;
                    isDragging = true;
                }
            }
        }

        // ����������� ������� ��� ������� ������ ����
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 newPosition = ray.GetPoint(offset.magnitude);

            // ������������ ����������� ������ �� ��� X
            newPosition.y = transform.position.y;
            newPosition.z = transform.position.z;

            // ��������� �������������
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * damping);
        }

        // ���������� ������� ��� ���������� ������ ����
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}

