using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public float damping = 5f; // Коэффициент демпфирования

    void Update()
    {
        // Проверка нажатия левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
           
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Проверка, что мы попали по объекту
            if (Physics.Raycast(ray, out hit))
            {
              
                if (hit.collider.gameObject == gameObject)
                {

                    // Запоминаем смещение от позиции объекта до позиции мыши
                    offset = transform.position - hit.point;
                    isDragging = true;
                }
            }
        }

        // Перемещение объекта при зажатой кнопке мыши
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 newPosition = ray.GetPoint(offset.magnitude);

            // Ограничиваем перемещение только по оси X
            newPosition.y = transform.position.y;
            newPosition.z = transform.position.z;

            // Применяем демпфирование
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * damping);
        }

        // Отпускание объекта при отпускании кнопки мыши
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}

