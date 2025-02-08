using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartDisassembly : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject modal;
    public GameObject modalText;
    void Start()
    {
        modal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDisassemblyFunc()
    {
        GameManager.instance.disassemblyStep = 1;

        modal.SetActive(true);
        modalText.GetComponent<TextMeshProUGUI>().text = "Нажмите на предохранительный замок";
    }
}
