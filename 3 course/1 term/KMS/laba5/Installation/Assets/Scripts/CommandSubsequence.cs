using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandSubsequence : MonoBehaviour
{
    
    public TextMeshProUGUI text;
   
    private int currentOperation;

    public GameObject Clocks;
    private Animator clocksAnimator;
    public RuntimeAnimatorController clocksMovingController;

    public GameObject FirstWeight;
    private Animator firstWeightAnimator;
    public RuntimeAnimatorController firstWeightController;

    public GameObject SecondWeight;
    private Animator secondWeightAnimator;
    public RuntimeAnimatorController secondWeightController;

    public GameObject ThirdWeight;
    private Animator thirdWeightAnimator;
    public RuntimeAnimatorController thirdWeightController;

    public GameObject FourthWeight;
    private Animator fourthWeightAnimator;
    public RuntimeAnimatorController fourthWeightController;


    public TextMeshProUGUI m1;
    public TextMeshProUGUI m2;
    public TextMeshProUGUI m3;
    public TextMeshProUGUI m4;


    private double currentWeightForTable;

    // Start is called before the first frame update
    void Start()
    {
        //clocksAnimator = GetComponent<Animator>();
        clocksAnimator = Clocks.GetComponent<Animator>();
        clocksAnimator.runtimeAnimatorController = clocksMovingController;

        firstWeightAnimator = FirstWeight.GetComponent<Animator>();
        firstWeightAnimator.runtimeAnimatorController = firstWeightController;

        secondWeightAnimator = SecondWeight.GetComponent<Animator>();
        secondWeightAnimator.runtimeAnimatorController = secondWeightController;

        thirdWeightAnimator = ThirdWeight.GetComponent<Animator>();
        thirdWeightAnimator.runtimeAnimatorController = thirdWeightController;

        fourthWeightAnimator = FourthWeight.GetComponent<Animator>();
        fourthWeightAnimator.runtimeAnimatorController = fourthWeightController;

        currentOperation = 0;
        currentWeightForTable = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstStep()
    {
        if (currentOperation != 0)
            return;
        text.text = "Задание 1. Передвиньте часы на расстояние l";
        currentOperation = 1;
      

        clocksAnimator.SetInteger("ClockCanMove", 100);

    }

    public void SecondStep()
    {
        Debug.Log(clocksAnimator.GetBool("ClockMoving"));
        //если мы еще не дошли дальше 2 задания и часы передвинуты
        if (!clocksAnimator.GetBool("ClockMoving") || currentOperation > 1)
            return;
        text.text = "Задание 2. Положите первый грузик на подвеску";
        firstWeightAnimator.SetInteger("FirstCanMove", 100);

        currentOperation = 2;
      
    }

    public void ThirdStep()
    {
       
        if (currentOperation != 2 || !firstWeightAnimator.GetBool("FirstWeight") )
            return;
        currentWeightForTable = 1.0;
       
        m1.text = currentWeightForTable.ToString();

        text.text = "Задание 3. Запишите данные в таблицу";
        currentOperation = 3;
        
    }



    public void FourthStep()
    {
        if (currentOperation != 3 )
            return;
        

        m1.text = currentWeightForTable.ToString();

        text.text = "Задание 4. Положите второй грузик на подвеску";
        secondWeightAnimator.SetInteger("SecondCanMove", 100);
        currentOperation = 4;

        //addedTextMeshPro
        GameObject addedTextObj = GameObject.Find("AddedText");
        TextMeshProUGUI comptext = addedTextObj.GetComponent<TextMeshProUGUI>();

        comptext.text = "";

    }

    public void FifthStep()
    {
        if (currentOperation != 4 || !secondWeightAnimator.GetBool("SecondWeight"))
            return;

      
        currentWeightForTable = 2.0;
     
        m2.text = currentWeightForTable.ToString();

        text.text = "Задание 5. Запишите данные в таблицу";
        currentOperation = 5;
        

    }


    public void SixthStep()
    {
        if (currentOperation != 5)
            return;
     

        m3.text = currentWeightForTable.ToString();

        text.text = "Задание 6. Положите третий грузик на подвеску";
        thirdWeightAnimator.SetInteger("ThirdCanMove", 100);
        currentOperation = 6;


        //addedTextMeshPro
        GameObject addedTextObj = GameObject.Find("AddedText");
        TextMeshProUGUI comptext = addedTextObj.GetComponent<TextMeshProUGUI>();

        comptext.text = "";

    }


    public void SeventhStep()
    {
        if (currentOperation != 6 || !thirdWeightAnimator.GetBool("ThirdWeight"))
            return;

       
        currentWeightForTable = 3.0;
       
        m3.text = currentWeightForTable.ToString();

        text.text = "Задание 7. Запишите данные в таблицу";
        currentOperation = 7;
       

    }

    public void EighthStep()
    {
        if (currentOperation != 7)
            return;
        

        m4.text = currentWeightForTable.ToString();

        text.text = "Задание 8. Положите четвертый грузик на подвеску";
        fourthWeightAnimator.SetInteger("FourthCanMove", 100);
        currentOperation = 8;

        //addedTextMeshPro
        GameObject addedTextObj = GameObject.Find("AddedText");
        TextMeshProUGUI comptext = addedTextObj.GetComponent<TextMeshProUGUI>();

        comptext.text = "";

    }

    public void NinethStep()
    {
        if (currentOperation != 8 || !fourthWeightAnimator.GetBool("FourthWeight"))
            return;

       
        currentWeightForTable = 4.0;
        
        m4.text = currentWeightForTable.ToString();

        text.text = "Задание 9. Запишите данные в таблицу";
        currentOperation = 9;
        

    }


    public void TenthStep()
    {

        if (currentOperation != 9)
            return;

        text.text = "Задание 10. Положите грузики на место";
        currentOperation = 10;

        //addedTextMeshPro
        GameObject addedTextObj = GameObject.Find("AddedText");
        TextMeshProUGUI comptext = addedTextObj.GetComponent<TextMeshProUGUI>();

        comptext.text = "";



        GameObject weight1Obj = GameObject.Find("Weight1");
        GameObject weight2Obj = GameObject.Find("Weight2");
        GameObject weight3Obj = GameObject.Find("Weight3");
        GameObject weight4Obj = GameObject.Find("Weight4");

        firstWeightAnimator.SetInteger("FirstCanMove", 100);
        secondWeightAnimator.SetInteger("SecondCanMove", 100);
        thirdWeightAnimator.SetInteger("ThirdCanMove", 100);
        fourthWeightAnimator.SetInteger("FourthCanMove", 100);


        GameObject curValObj = GameObject.Find("CurrentValue");

        curValObj.SetActive(false);
        thirdWeightAnimator.SetBool("HidePanel", true);



    }

    public void OnMouseDown()
    {
       
    }

    public void OnPointerExit()
    {
        
    }
}
