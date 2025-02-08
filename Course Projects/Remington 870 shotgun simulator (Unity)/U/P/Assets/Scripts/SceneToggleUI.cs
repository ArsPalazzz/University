using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneToggleUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleBtn()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
