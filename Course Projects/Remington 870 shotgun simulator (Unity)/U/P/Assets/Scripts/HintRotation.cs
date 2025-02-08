using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintRotation : MonoBehaviour
{
    private Transform mainCameraTransform;

    void Start()
    {
        mainCameraTransform = GameObject.Find("Main Camera").transform;
        TMP_Text textMeshPro = GameObject.Find("Pick up the weapon hint").GetComponent<TMP_Text>();

        if (textMeshPro != null)
        {
            textMeshPro.color = Color.black;
        }
    }

    void Update()
    {
       
        transform.LookAt(mainCameraTransform);
        transform.Rotate(0, 180, 0);
    }
}
