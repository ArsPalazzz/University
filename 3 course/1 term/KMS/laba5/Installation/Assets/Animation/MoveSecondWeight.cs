using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MoveSecondWeight : MonoBehaviour
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
    public GameObject thirdWeight;
    public GameObject fourthWeight;

    private Animator firstWeightAnimator;
    private Animator thirdWeightAnimator;
    private Animator fourthWeightAnimator;

    public RuntimeAnimatorController firstWeightController;
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




        firstWeightAnimator = firstWeight.GetComponent<Animator>();
        thirdWeightAnimator = thirdWeight.GetComponent<Animator>();
        fourthWeightAnimator = fourthWeight.GetComponent<Animator>();


        firstWeightAnimator.runtimeAnimatorController = firstWeightController;
        thirdWeightAnimator.runtimeAnimatorController = thirdWeightController;
        fourthWeightAnimator.runtimeAnimatorController = fourthWeightController;
    }

    public void OnMouseDown()
    {

        if (anime.GetInteger("SecondCanMove") != 100)
        {
            return;
        }

        //если второй грузик в первом кадре анимации
        if (!anime.GetBool("SecondWeight"))
        {
            if (firstWeightAnimator.GetBool("FirstWeight")  && !thirdWeightAnimator.GetBool("ThirdWeight") && !fourthWeightAnimator.GetBool("FourthWeight"))
            {

            }
            else
            {
                Debug.Log("Pick the upper weight");
                return;
            }
        }
        else if (anime.GetBool("SecondWeight"))
        {
            if (firstWeightAnimator.GetBool("FirstWeight") && !thirdWeightAnimator.GetBool("ThirdWeight") && !fourthWeightAnimator.GetBool("FourthWeight"))
            {
                da = false;
            }
            else
            {
                Debug.Log("Pick the upper weight");
                return;
            }
        }

        currentState = !currentState;
        //anime.SetBool("FirstWeight", currentState);
        anime.SetBool("SecondWeight", true);
        anime.SetFloat("ForwardMovement", 1.0f);
        pendantAnimator.SetFloat("ForwardMovement2", 1.0f);
        arrowAnimator.SetFloat("ForwardMovement2", 1.0f);
        metalBalkaAnimator.SetFloat("ForwardMovement2", 1.0f);
        //metalBalkaAnimator.SetTrigger("FirstToSecond");


        //for reverse animation
        if (!currentState)
        {
            anime.SetBool("SecondWeight", true);
            anime.SetFloat("ForwardMovement", -1.0f);
            pendantAnimator.SetFloat("ForwardMovement2", -1.0f);
            arrowAnimator.SetFloat("ForwardMovement2", -1.0f);
            metalBalkaAnimator.SetFloat("ForwardMovement2", -1.0f);
            StartPendantAndArrowChanges();


            anime.SetBool("SecondWeight", da);
        }


    }

    void Update()
    {

    }

    public void StartPendantAndArrowChanges()
    {
        pendantAnimator.SetBool("PendantMovement2", currentState);

        Quaternion currentRotation = Arrow.transform.rotation;
        //arrowAnimator.SetBool("ArrowParent2", currentState);


        metalBalkaAnimator.SetBool("FixedBalkaRotation2", currentState);



        //double BC = (l * Math.Sqrt(2 - 2 * Math.Cos(MetalBalka.transform.rotation.x)));
        //Debug.Log(MetalBalka.transform.rotation.x);
        //double ABC = Math.Acos(1.0 - BC * BC / (2.0 * l * l));
        //double lyamdba = BC * Math.Tan(ABC) * 1.0E15;

        double lyambda;
        if (anime.GetBool("SecondWeight"))
        {
            lyambda = 2 * Math.Sin(0.35) * 1E1;
        }
        else
        {
            lyambda = 2 * Math.Sin(0.2) * 1E1;
        }


        float fixedRotationAngle = (float)(lyambda * 3.6);

       


        Arrow.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z + fixedRotationAngle);

        anime.SetInteger("SecondCanMove", 0);


        if (!thirdWeightAnimator.GetBool("HidePanel"))
        {
            GameObject currentValueObj = GameObject.Find("CurrentValue");
            TextMeshProUGUI comptext = currentValueObj.GetComponent<TextMeshProUGUI>();

            string lyambdaString = lyambda.ToString();
            comptext.text = "Текущее значение лямбды " + lyambdaString.Substring(0, Math.Min(lyambdaString.Length, 4));
        }

    }

}
