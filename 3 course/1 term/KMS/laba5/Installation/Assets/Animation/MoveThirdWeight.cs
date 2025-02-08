using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MoveThirdWeight : MonoBehaviour
{
    Animator anime;
    // public GameObject pendantBalka;
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

    public GameObject firstWeight;
    public GameObject secondWeight;
    public GameObject fourthWeight;

    private Animator firstWeightAnimator;
    private Animator secondWeightAnimator;
    private Animator fourthWeightAnimator;

    public RuntimeAnimatorController firstWeightController;
    public RuntimeAnimatorController secondWeightController;
    public RuntimeAnimatorController fourthWeightController;

    private double l = 1.0;

    //private bool da = true;


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


        firstWeightAnimator = firstWeight.GetComponent<Animator>();
        secondWeightAnimator = secondWeight.GetComponent<Animator>();
        fourthWeightAnimator = fourthWeight.GetComponent<Animator>();


        firstWeightAnimator.runtimeAnimatorController = firstWeightController;
        secondWeightAnimator.runtimeAnimatorController = secondWeightController;
        fourthWeightAnimator.runtimeAnimatorController = fourthWeightController;
    }

    public void OnMouseDown()
    {

        

        if (anime.GetInteger("ThirdCanMove") != 100)
        {
            return;
        }


        //если второй грузик в первом кадре анимации
        if (!anime.GetBool("ThirdWeight"))
        {
            Debug.Log("First if");
            if (firstWeightAnimator.GetBool("FirstWeight") && secondWeightAnimator.GetBool("SecondWeight") && !fourthWeightAnimator.GetBool("FourthWeight"))
            {

            }
            else
            {
                Debug.Log("Pick the upper weight31");
                return;
            }
        }
        else if (anime.GetBool("ThirdWeight"))
        {
            Debug.Log("Second if");
            if (firstWeightAnimator.GetBool("FirstWeight") && secondWeightAnimator.GetBool("SecondWeight") && !fourthWeightAnimator.GetBool("FourthWeight"))
            {
               
            }
            else
            {
                Debug.Log("Pick the upper weight32");
                return;
            }
        }





        currentState = !currentState;
        //anime.SetBool("FirstWeight", currentState);
        anime.SetBool("ThirdWeight", true);
        anime.SetFloat("ForwardMovement", 1.0f);
        pendantAnimator.SetFloat("ForwardMovement3", 1.0f);
        arrowAnimator.SetFloat("ForwardMovement3", 1.0f);
        metalBalkaAnimator.SetFloat("ForwardMovement3", 1.0f);
        //metalBalkaAnimator.SetTrigger("FirstToSecond");
        //anime.SetBool("ThirdWeight", da);

        //for reverse animation
        if (!currentState)
        {
            anime.SetBool("ThirdWeight", true);
            anime.SetFloat("ForwardMovement", -1.0f);
            pendantAnimator.SetFloat("ForwardMovement3", -1.0f);
            arrowAnimator.SetFloat("ForwardMovement3", -1.0f);
            metalBalkaAnimator.SetFloat("ForwardMovement3", -1.0f);
            StartPendantAndArrowChanges();



            //anime.SetBool("ThirdWeight", da);
        }


    }

    void Update()
    {

    }

    public void StartPendantAndArrowChanges()
    {
        pendantAnimator.SetBool("PendantMovement3", currentState);


        //arrowAnimator.SetBool("ArrowParent3", currentState);


        metalBalkaAnimator.SetBool("FixedBalkaRotation3", currentState);



        Quaternion currentRotation = Arrow.transform.rotation;

        double lyambda;
        Debug.Log(anime.GetBool("ThirdWeight"));
        if (anime.GetBool("ThirdWeight"))
        {
            lyambda = 2 * Math.Sin(0.40) * 1E1;
        }
        else
        {
            lyambda = 2 * Math.Sin(0.35) * 1E1;
        }

     

       
        float fixedRotationAngle = (float)(lyambda * 3.6);



        Arrow.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z + fixedRotationAngle);

        anime.SetInteger("ThirdCanMove", 0);




        if (!anime.GetBool("HidePanel"))
        {
            GameObject currentValueObj = GameObject.Find("CurrentValue");
            TextMeshProUGUI comptext = currentValueObj.GetComponent<TextMeshProUGUI>();

            string lyambdaString = lyambda.ToString();
            comptext.text = "Текущее значение лямбды " + lyambdaString.Substring(0, Math.Min(lyambdaString.Length, 4));
        }


    }
}
