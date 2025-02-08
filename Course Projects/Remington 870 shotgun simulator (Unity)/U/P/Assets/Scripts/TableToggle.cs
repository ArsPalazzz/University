using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableToggle : MonoBehaviour
{
    public GameObject Table;
    // Start is called before the first frame update
    void Start()
    {
        Table.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TableToggler()
    {
       
            if (Table != null)
            {
            Table.SetActive(!Table.activeSelf);
            }
        
    }
}
