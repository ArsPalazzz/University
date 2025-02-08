using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClocks : MonoBehaviour
{
    private Animator clocksAnimator;
   
    void Start()
    {
        clocksAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (clocksAnimator.GetInteger("ClockCanMove") == 100)
        {
            clocksAnimator.SetBool("ClockMoving", true);
        }

        
    } 
}
