using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentScene
{
    ShootingRange,
    Assembly,
    Disassembly
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

   

    // ���������� ����������
    public int score = 0;
    public bool isWeaponPicked = false;
    public string playerName = "Player";
    public int numPellets = 4;

   public CurrentScene currentScene = CurrentScene.Disassembly;
    public int disassemblyStep = 0;
    public int currentRow = 0;
    public bool isShooted = false;

    public Vector3 weaponMainPosition;
    public Vector3 weaponAddPosition;

    public Quaternion weaponMainRotation;
    public Quaternion weaponAddRotation;

    private void Awake()
    {
        // ����������, ��� ���������� ������ ���� ��������� GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ������ ��� �������� ����� �����
            GameObject player = GameObject.Find("Main Camera");

            if (currentScene == CurrentScene.ShootingRange)
            {
                Transform shootingRangeLocation = GameObject.Find("ShootingRangeLocation").transform;

                player.transform.position = shootingRangeLocation.position;
                player.transform.rotation = shootingRangeLocation.rotation;
                //Cursor.visible = false;
            }
            else if (currentScene == CurrentScene.Assembly)
            {
                Transform assemblyRoomLocation = GameObject.Find("AssemblyLocation").transform;

                player.transform.position = assemblyRoomLocation.position;
                player.transform.rotation = assemblyRoomLocation.rotation;
                //Cursor.visible = true;
            }
            else if (currentScene == CurrentScene.Disassembly)
            {
                Transform disAssemblyRoomLocation = GameObject.Find("DisassemblyLocation").transform;

                player.transform.position = disAssemblyRoomLocation.position;
                player.transform.rotation = disAssemblyRoomLocation.rotation;
                //Cursor.visible = true;
            }
        }
        else
        {
            Destroy(gameObject); // ���������� ������� ������, ���� ��� ���������� ������ ���������
        }
    }
}
