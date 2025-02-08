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
        // ��������� ����������� ���� �������
        originalColor = targetObject.GetComponent<Renderer>().material.color;
    }

    // ���������� ��� ��������� ������� �� ������
    public void OnPointerEnter(PointerEventData eventData)
    {
        // ������ ���� �������� ������� �� hoverColor ��� ��������� �� ������
        targetObject.GetComponent<Renderer>().material.color = hoverColor;
    }

    // ���������� ��� ����� ������� � ������
    public void OnPointerExit(PointerEventData eventData)
    {
        // ���������� ����������� ���� �������� ������� ��� ����� ������� � ������
        targetObject.GetComponent<Renderer>().material.color = originalColor;
    }
}
