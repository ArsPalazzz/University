using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetScript : MonoBehaviour
{
    public int targetNumber; // Номер мишени

    public GameObject text11;
    public GameObject text12;

    public GameObject text21;
    public GameObject text22;

    public GameObject text31;
    public GameObject text32;

    public GameObject text41;
    public GameObject text42;

    public GameObject text51;
    public GameObject text52;

    public GameObject text61;
    public GameObject text62;

    public GameObject text71;
    public GameObject text72;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Получаем скорость пули из её компонента Bullet
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            float bulletSpeed = bullet.GetCurrentSpeed();
            if (GameManager.instance.currentRow < 7 && GameManager.instance.isShooted) GameManager.instance.currentRow++;


            // Выводим скорость пули в консоль
            GameManager.instance.isShooted = false;
            Debug.Log("Speed of bullet on collision with target " + targetNumber + ": " + bulletSpeed);
            if (GameManager.instance.currentRow == 1)
            {
                text11.GetComponent<TextMeshProUGUI>().text = targetNumber.ToString();
                text12.GetComponent<TextMeshProUGUI>().text = bulletSpeed.ToString();
            }
            else if (GameManager.instance.currentRow == 2)
            {
                text21.GetComponent<TextMeshProUGUI>().text = targetNumber.ToString();
                text22.GetComponent<TextMeshProUGUI>().text = bulletSpeed.ToString();
            }
            else if (GameManager.instance.currentRow == 3)
            {
                text31.GetComponent<TextMeshProUGUI>().text = targetNumber.ToString();
                text32.GetComponent<TextMeshProUGUI>().text = bulletSpeed.ToString();
            }
            else if (GameManager.instance.currentRow == 4)
            {
                text41.GetComponent<TextMeshProUGUI>().text = targetNumber.ToString();
                text42.GetComponent<TextMeshProUGUI>().text = bulletSpeed.ToString();
            }
            else if (GameManager.instance.currentRow == 5)
            {
                text51.GetComponent<TextMeshProUGUI>().text = targetNumber.ToString();
                text52.GetComponent<TextMeshProUGUI>().text = bulletSpeed.ToString();
            }
            else if (GameManager.instance.currentRow == 6)
            {
                text61.GetComponent<TextMeshProUGUI>().text = targetNumber.ToString();
                text62.GetComponent<TextMeshProUGUI>().text = bulletSpeed.ToString();
            }
            else if (GameManager.instance.currentRow == 7)
            {
                text71.GetComponent<TextMeshProUGUI>().text = targetNumber.ToString();
                text72.GetComponent<TextMeshProUGUI>().text = bulletSpeed.ToString();
            }


            // Далее вы можете использовать скорость пули в вашей логике, например, для подсчета очков или других действий
        }

        Destroy(collision.gameObject);
    }
}
