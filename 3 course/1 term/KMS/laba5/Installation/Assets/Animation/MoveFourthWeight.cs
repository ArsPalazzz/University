using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class MoveFourthWeight : MonoBehaviour
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
    public GameObject thirdWeight;
   

    private Animator firstWeightAnimator;
    private Animator secondWeightAnimator;
    private Animator thirdWeightAnimator;
    

    public RuntimeAnimatorController firstWeightController;
    public RuntimeAnimatorController secondWeightController;
    public RuntimeAnimatorController thirdWeightController;

    private double l = 1.0;


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
        thirdWeightAnimator = thirdWeight.GetComponent<Animator>();


        firstWeightAnimator.runtimeAnimatorController = firstWeightController;
        secondWeightAnimator.runtimeAnimatorController = secondWeightController;
        thirdWeightAnimator.runtimeAnimatorController = thirdWeightController;
    }

    public void OnMouseDown()
    {

        if (anime.GetInteger("FourthCanMove") != 100)
        {
            return;
        }
        //если второй грузик в первом кадре анимации
        if (!anime.GetBool("FourthWeight"))
        {
            Debug.Log("First cadr");
            if (firstWeightAnimator.GetBool("FirstWeight") && secondWeightAnimator.GetBool("SecondWeight") && thirdWeightAnimator.GetBool("ThirdWeight"))
            {
                
            }
            else
            {
                Debug.Log("Pick the upper weight41");
                return;
            }
        }
        //если второй грузик в последнем кадре анимации
        else if (anime.GetBool("FourthWeight"))
        {
            Debug.Log("Last cadr");
            if (firstWeightAnimator.GetBool("FirstWeight") && secondWeightAnimator.GetBool("SecondWeight") && thirdWeightAnimator.GetBool("ThirdWeight"))
            {
                //currentState = !currentState;
            }
            else
            {
                Debug.Log("Pick the upper weight42");
                return;
            }
        }


        currentState = !currentState;
        //anime.SetBool("FirstWeight", currentState);
        anime.SetBool("FourthWeight", true);
        anime.SetFloat("ForwardMovement", 1.0f);
        pendantAnimator.SetFloat("ForwardMovement4", 1.0f);
        arrowAnimator.SetFloat("ForwardMovement4", 1.0f);
        metalBalkaAnimator.SetFloat("ForwardMovement4", 1.0f);
        //metalBalkaAnimator.SetTrigger("FirstToSecond");


        



        //for reverse animation
        if (!currentState)
        {
            Debug.Log("off animation");
            anime.SetBool("FourthWeight", true);
            anime.SetFloat("ForwardMovement", -1.0f);
            pendantAnimator.SetFloat("ForwardMovement4", -1.0f);
            arrowAnimator.SetFloat("ForwardMovement4", -1.0f);
            
            metalBalkaAnimator.SetFloat("ForwardMovement4", -1.0f);
            StartPendantAndArrowChanges();
        }


    }

    void Update()
    {

    }

    public void StartPendantAndArrowChanges()
    {
        
        pendantAnimator.SetBool("PendantMovement4", currentState);


      


        metalBalkaAnimator.SetBool("FixedBalkaRotation4", currentState);

        if (!currentState)
        {
            anime.SetBool("FourthWeight", false);
        }



        Quaternion currentRotation = Arrow.transform.rotation;
        double lyambda;
        Debug.Log(anime.GetBool("FourthWeight"));
        if (anime.GetBool("FourthWeight")){
            lyambda = 2 * Math.Sin(0.42) * 1E1;
        }
        else
        {
            lyambda = 2 * Math.Sin(0.40) * 1E1;
        }
        

       
        float fixedRotationAngle = (float)(lyambda * 3.6);

       


        Arrow.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z + fixedRotationAngle);

        anime.SetInteger("FourthCanMove", 0);


        if (!thirdWeightAnimator.GetBool("HidePanel"))
        {
            GameObject currentValueObj = GameObject.Find("CurrentValue");
            TextMeshProUGUI comptext = currentValueObj.GetComponent<TextMeshProUGUI>();

            string lyambdaString = lyambda.ToString();
            comptext.text = "Текущее значение лямбды " + lyambdaString.Substring(0, Math.Min(lyambdaString.Length, 4));
        }

    }
}
