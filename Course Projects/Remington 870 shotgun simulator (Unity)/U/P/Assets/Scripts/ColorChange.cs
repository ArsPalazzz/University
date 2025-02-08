using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject targetObject;
    private Color originalColor;
    public Color hoverColor = Color.red;

    private void Start()
    {
        // Сохраняем изначальный цвет объекта
        originalColor = targetObject.GetComponent<Renderer>().material.color;
    }

    // Вызывается при наведении курсора на кнопку
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Меняем цвет целевого объекта на hoverColor при наведении на кнопку
        targetObject.GetComponent<Renderer>().material.color = hoverColor;
    }

    // Вызывается при уходе курсора с кнопки
    public void OnPointerExit(PointerEventData eventData)
    {
        // Возвращаем изначальный цвет целевого объекта при уходе курсора с кнопки
        targetObject.GetComponent<Renderer>().material.color = originalColor;
    }
}
