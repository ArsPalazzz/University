using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MoveFirstWeight : MonoBehaviour
{
    Animator anime;
   
    bool currentState;

    public GameObject Pendant;
    public GameObject Arrow;
    public GameObject MetalBalka;

    private Animator pendantAnimator;
    private Animator arrowAnimator;
    private Animator metalBalkaAnimator;

    public RuntimeAnimatorController pendantRotationController;
    public RuntimeAnimatorController arrowRotationController;
    public RuntimeAnimatorController metalBalkaRotationController;


    public GameObject secondWeight;
    public GameObject thirdWeight;
    public GameObject fourthWeight;

    private Animator secondWeightAnimator;
    private Animator thirdWeightAnimator;
    private Animator fourthWeightAnimator;

    public RuntimeAnimatorController secondWeightController;
    public RuntimeAnimatorController thirdWeightController;
    public RuntimeAnimatorController fourthWeightController;

    private double l = 1.0;

    private bool da = true;


    void Start()
    {
        anime = GetComponent<Animator>();

        pendantAnimator = Pendant.GetComponent<Animator>();
        arrowAnimator = Arrow.GetComponent<Animator>();
        metalBalkaAnimator = MetalBalka.GetComponent<Animator>();
        currentState = false;

        // Установите контроллер анимации для объекта Pendant
        pendantAnimator.runtimeAnimatorController = pendantRotationController;
        arrowAnimator.runtimeAnimatorController = arrowRotationController;
        metalBalkaAnimator.runtimeAnimatorController = metalBalkaRotationController;



        secondWeightAnimator = secondWeight.GetComponent<Animator>();
        thirdWeightAnimator = thirdWeight.GetComponent<Animator>();
        fourthWeightAnimator = fourthWeight.GetComponent<Animator>();


        secondWeightAnimator.runtimeAnimatorController = secondWeightController;
        thirdWeightAnimator.runtimeAnimatorController = thirdWeightController;
        fourthWeightAnimator.runtimeAnimatorController = fourthWeightController;
    }

    public void OnMouseDown() 
    {

        if (anime.GetInteger("FirstCanMove") != 100)
        {
            return;
        }

        

        //если перый грузик в последнем кадре анимации
        if (anime.GetBool("FirstWeight"))
        {
           
            if (secondWeightAnimator.GetBool("SecondWeight") || thirdWeightAnimator.GetBool("ThirdWeight") || fourthWeightAnimator.GetBool("FourthWeight"))
            {
                Debug.Log("Pick the upper weight");
                return;
            }

            da = false;
            // Код, который выполнится, если все три условия ложны

        }
        //если перый грузик в первом кадре анимации
        else if (!anime.GetBool("FirstWeight"))
        {
            //
            if (!secondWeightAnimator.GetBool("SecondWeight") && !thirdWeightAnimator.GetBool("ThirdWeight") && !fourthWeightAnimator.GetBool("FourthWeight"))
            {

            }
            else
            {
                Debug.Log("Pick the upper weight");
                return;
            }
        }
       
        currentState = !currentState;
        //anime.SetBool("FirstWeight", currentState);
        anime.SetBool("FirstWeight", true);
        anime.SetFloat("ForwardMovement", 1.0f);
        pendantAnimator.SetFloat("ForwardMovement", 1.0f);
        arrowAnimator.SetFloat("ForwardMovement", 1.0f);
        metalBalkaAnimator.SetFloat("ForwardMovement", 1.0f);


        //for reverse animation
        if (!currentState)
        {
            anime.SetBool("FirstWeight", true);
            anime.SetFloat("ForwardMovement", -1.0f);
            pendantAnimator.SetFloat("ForwardMovement", -1.0f);
            arrowAnimator.SetFloat("ForwardMovement", -1.0f);
            metalBalkaAnimator.SetFloat("ForwardMovement", -1.0f);
            StartPendantAndArrowChanges();

            anime.SetBool("FirstWeight", da);
        }



    }

    void Update()
    {
        
    }

    public void StartPendantAndArrowChanges()
    {
        pendantAnimator.SetBool("PendantMovement", currentState);

        Quaternion currentRotation = Arrow.transform.rotation;


        metalBalkaAnimator.SetBool("FixedBalkaRotation", currentState);


        double lyambda;
        if (anime.GetBool("FirstWeight"))
        {
            lyambda = 2 * Math.Sin(0.2) * 1E1;
        }
        else
        {
            lyambda = 2 * Math.Sin(0) * 1E1;
        }

        float fixedRotationAngle = (float)(lyambda * 3.6);

        
        Arrow.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z + fixedRotationAngle);

        anime.SetInteger("FirstCanMove", 0);



       if (!thirdWeightAnimator.GetBool("HidePanel"))
        {
            GameObject currentValueObj = GameObject.Find("CurrentValue");
            TextMeshProUGUI comptext = currentValueObj.GetComponent<TextMeshProUGUI>();

            string lyambdaString = lyambda.ToString();
            comptext.text = "Текущее значение лямбды " + lyambdaString.Substring(0, Math.Min(lyambdaString.Length, 4));
        }
           
      

    }

}
