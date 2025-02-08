using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CleanTable : MonoBehaviour
{

    public TextMeshProUGUI m1;
    public TextMeshProUGUI m2;
    public TextMeshProUGUI m3;
    public TextMeshProUGUI m4;
    public TextMeshProUGUI lyambda1;
    public TextMeshProUGUI lyambda2;
    public TextMeshProUGUI lyambda3;
    public TextMeshProUGUI lyambda4;
    public TextMeshProUGUI k1;
    public TextMeshProUGUI k2;
    public TextMeshProUGUI k3;
    public TextMeshProUGUI k4;
    public TextMeshProUGUI averageK;
    public TextMeshProUGUI e;
    public TextMeshProUGUI eE;
    public TextMeshProUGUI delE;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        m1.text = "";
        m2.text = "";
        m3.text = "";
        m4.text = "";
        lyambda1.text = "";
        lyambda2.text = "";
        lyambda3.text = "";
        lyambda4.text = "";
        k1.text = "";
        k2.text = "";
        k3.text = "";
        k4.text = "";
        averageK.text = "";
        e.text = "";
        eE.text = "";
        delE.text = "";
    }
}
