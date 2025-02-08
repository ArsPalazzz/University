using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsPanelScript : MonoBehaviour
{
    private bool isVisible;
    //public GameObject StepsPanelObj;
    // Start is called before the first frame update
    void Start()
    {
        isVisible = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleStepsPanel()
    {
        isVisible = !isVisible;
        gameObject.SetActive(isVisible);
    }
}
