using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator shotgunAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimationComplete()
    {
        shotgunAnimator.SetBool("afterShot", false);
    }
}
