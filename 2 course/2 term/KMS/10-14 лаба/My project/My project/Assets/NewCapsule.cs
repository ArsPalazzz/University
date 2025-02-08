using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCapsule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float moveSpeed = 5f; // скорость перемещения объекта

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // получаем значение оси горизонтального перемещения мыши
        float vertical = Input.GetAxis("Vertical"); // получаем значение оси вертикального перемещения мыши

        // перемещаем объект в соответствии со значениями осей
        transform.Translate(new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime);
    }

    public GameObject cube1;
    public GameObject cube2;
  

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "cube1")
        {
            cube1.GetComponent<Renderer>().material.color = Color.green;
            
        }
        if (col.gameObject.name == "cube2")
        {
            cube2.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}





//Texture newTexture = Resources.Load<Texture>("GrassHillAlbedo");
            //cube1.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>("GrassHillAlbedo");
            //clouds1_down
            //Texture2D tex = Resources.Load("GrassHillAlbedo.psd") as Texture2D;
            //cube1.GetComponent<Renderer>().material.SetTexture("_MainTex", tex);