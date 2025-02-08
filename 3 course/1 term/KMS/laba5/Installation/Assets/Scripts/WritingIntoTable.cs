using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class WritingIntoTable : MonoBehaviour
{
    public TextMeshProUGUI groundText;
    public TextMeshProUGUI lyambda1Textbox;
    public TextMeshProUGUI lyambda2Textbox;
    public TextMeshProUGUI lyambda3Textbox;
    public TextMeshProUGUI lyambda4Textbox;
    public TextMeshProUGUI k1Textbox;
    public TextMeshProUGUI k2Textbox;
    public TextMeshProUGUI k3Textbox;
    public TextMeshProUGUI k4Textbox;
    public TextMeshProUGUI kAverageTextbox;
    public TextMeshProUGUI eTextbox;
    public TextMeshProUGUI eETextbox;
    public TextMeshProUGUI delETextbox;
    public TMP_InputField input;

    private double m = 1;
    private double l = 1.0;
    private double a;
    private double b;

    // Start is called before the first frame update
    void Start()
    {
        GameObject weight = GameObject.Find("Weight1");

        Renderer objectRenderer = weight.GetComponent<Renderer>();

        Vector3 objectSize = objectRenderer.bounds.size;

        a = objectSize.x;
        b = objectSize.z;


        if (input != null)
        {
            // Добавляем слушатель события изменения текста в InputField
            input.onValueChanged.AddListener(OnInputValueChanged);
        }

    }


    void OnInputValueChanged(string value)
    {
        // Фильтруем введенные символы, оставляя только цифры
        string filteredValue = FilterNonNumeric(value);

        // Обновляем текст в InputField
        input.text = filteredValue;
    }

    string FilterNonNumeric(string value)
    {
        // Фильтруем введенные символы, оставляя только цифры
        string result = "";
        foreach (char character in value)
        {
            if (char.IsDigit(character) || character == ',')
            {
                result += character;
            }
        }
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (input.text == "")
        {
            return;
        }



        if (groundText.text.StartsWith("Задание 3"))
        {
            string currentText = input.text;
            input.text = "";
           
            lyambda1Textbox.text = currentText;

            double k1value = (m * 9.81) / (2 * double.Parse(lyambda1Textbox.text));

            string fullstring = k1value.ToString();

            k1Textbox.text = fullstring.Substring(0, Math.Min(fullstring.Length, 4));



            //addedTextMeshPro
            GameObject addedTextObj = GameObject.Find("AddedText");
            TextMeshProUGUI comptext = addedTextObj.GetComponent<TextMeshProUGUI>();

            comptext.text = "Success";

        }

        else if (groundText.text.StartsWith("Задание 5"))
        {
            string currentText = input.text;
            input.text = "";

            m = 2;
        
        lyambda2Textbox.text = currentText;

            double k2value = (m * 9.81) / (2 * double.Parse(lyambda2Textbox.text));

            string fullstring = k2value.ToString();

            k2Textbox.text = fullstring.Substring(0, Math.Min(fullstring.Length, 4));



            //addedTextMeshPro
            GameObject addedTextObj = GameObject.Find("AddedText");
            TextMeshProUGUI comptext = addedTextObj.GetComponent<TextMeshProUGUI>();

            comptext.text = "Success";

        }

        else if (groundText.text.StartsWith("Задание 7"))
        {
            string currentText = input.text;
            input.text = "";

            m = 3;
            
            lyambda3Textbox.text = currentText;

            double k3value = (m * 9.81) / (2 * double.Parse(lyambda3Textbox.text));

            string fullstring = k3value.ToString();

            k3Textbox.text = fullstring.Substring(0, Math.Min(fullstring.Length, 4));



            //addedTextMeshPro
            GameObject addedTextObj = GameObject.Find("AddedText");
            TextMeshProUGUI comptext = addedTextObj.GetComponent<TextMeshProUGUI>();

            comptext.text = "Success";

        }

        else if (groundText.text.StartsWith("Задание 9"))
        {
            string currentText = input.text;
            input.text = "";

            m = 4;
           
            lyambda4Textbox.text = currentText;

            double k4value = (m * 9.81) / (2 * double.Parse(lyambda4Textbox.text));

            string fullstring = k4value.ToString();

            k4Textbox.text = fullstring.Substring(0, Math.Min(fullstring.Length, 4));

            string kAverageValue = ((double.Parse(k1Textbox.text) + double.Parse(k2Textbox.text) + double.Parse(k3Textbox.text) + double.Parse(k4Textbox.text)) / 4).ToString();
            kAverageTextbox.text = kAverageValue.Substring(0, Math.Min(kAverageValue.Length, 4));

            string eValue = (4 * Math.Pow(l, 3) * double.Parse(kAverageTextbox.text) / (a * Math.Pow(b, 3))).ToString();
            eTextbox.text = eValue.Substring(0, Math.Min(eValue.Length, 4));

            string eEValue = (9 * Math.Pow(0.001 / l, 2) + Math.Pow(0.001 / double.Parse(kAverageTextbox.text), 2) + Math.Pow(0.001 / a, 2) + 9 * Math.Pow(0.001 / b, 2)).ToString();
            eETextbox.text = eEValue.Substring(0, Math.Min(eEValue.Length, 4));

            string delEEValue = (double.Parse(eTextbox.text) * double.Parse(eETextbox.text)).ToString();
            delETextbox.text = delEEValue.Substring(0, Math.Min(delEEValue.Length, 6));



            //addedTextMeshPro
            GameObject addedTextObj = GameObject.Find("AddedText");
            TextMeshProUGUI comptext = addedTextObj.GetComponent<TextMeshProUGUI>();

            comptext.text = "Success";



           


        }



    }
}
