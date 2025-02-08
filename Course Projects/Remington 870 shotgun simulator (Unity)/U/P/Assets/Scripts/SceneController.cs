using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject player;
    public Transform shootingRangeLocation;
    public Transform assemblyRoomLocation; 
    public Transform disAssemblyRoomLocation;

    public GameObject DetailsDisassemblyUI;
    public GameObject StartDisassemblyUI;
    public GameObject ModalDisUI;

    public void ToDisassemblyLocation()
    {
        if (GameManager.instance.currentScene == CurrentScene.Disassembly)
            return;

        player.transform.position = disAssemblyRoomLocation.position;
        player.transform.rotation = disAssemblyRoomLocation.rotation;

        GameManager.instance.currentScene = CurrentScene.Disassembly;
        //Cursor.visible = true;
        DetailsDisassemblyUI.SetActive(true);
        StartDisassemblyUI.SetActive(true);
        ModalDisUI.SetActive(true);
        Camera.main.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ToShootingRangeLocation()
    {
        if (GameManager.instance.currentScene == CurrentScene.ShootingRange)
            return;

        player.transform.position = shootingRangeLocation.position;
        player.transform.rotation = shootingRangeLocation.rotation;

        GameManager.instance.currentScene = CurrentScene.ShootingRange;
        //Cursor.visible = false;
        DetailsDisassemblyUI.SetActive(false);
        StartDisassemblyUI.SetActive(false);
        ModalDisUI.SetActive(false);
        Camera.main.GetComponent<Rigidbody>().isKinematic = false;
    }
}
