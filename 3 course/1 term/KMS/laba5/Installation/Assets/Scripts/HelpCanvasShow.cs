﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpCanvasShow : MonoBehaviour
{
    public Canvas helpCanvas;
    private bool isCanvasVisible;

    void Start()
    {
        isCanvasVisible = false;
        helpCanvas.gameObject.SetActive(false);

       
    }

    public void ToggleHelpCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        helpCanvas.gameObject.SetActive(isCanvasVisible);
    }
}
