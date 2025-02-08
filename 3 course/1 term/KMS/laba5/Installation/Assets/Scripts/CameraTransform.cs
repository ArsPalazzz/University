using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    [SerializeField]
    Transform target;
    float scrollSpeed = 5f;    // скорость вращения и передвижения камеры
    int rotationSensivity = 7;
    int maxDistance = 10;
    int minDistance = 1;
 
    void Start()
    {
        transform.LookAt(target);
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        // Движение камеры влево-право, вниз-вверх ADSW.
        if (!Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Horizontal"); 
            float y = -Input.GetAxis("Vertical"); 
            if (x != 0 || y != 0)
            {
                Vector3 newPos = transform.position + (transform.TransformDirection(new Vector3(x, 0, 0)) + Vector3.forward * y) / rotationSensivity;
                if (ControlDistance(Vector3.Distance(newPos, target.position))) 
                {
                    transform.position = newPos;
                }
            }
        }
        // Приближение камеры колёсиком мыши.
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward 
            * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
            if (ControlDistance(Vector3.Distance(newPos, target.position))) transform.position = newPos;
        }

        // Вращение вокруг установки.
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * scrollSpeed);
        }

        if (move)
        {
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            transform.rotation = Quaternion.Slerp(startRotation, needRotaton, offset);
            if (offset >= 1)
            {
                move = false;
                offset = 0;
            }
        }
    }

    // Функция ограничения пределов движения камеры.
    bool ControlDistance (float distance)
    {
        if (distance > minDistance && distance < maxDistance) 
        {
            return true;
        }
        return false;
    }

    Vector3 startPosition;
    Vector3 needPosition;
    bool move = false;
    float speed = 0.07f;
    float offset = 0;
    Quaternion startRotation;
    Quaternion needRotaton;


    

    public void ZoomToWeights()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(-74.3f, 4.78f, -1.96f);
            
        }
    }

    public void ZoomToPendant()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(-76.73f, 5.42f, -2.22f);
          
        }
    }

    public void ZoomToMetalBalka()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(-78.262f, 5.626f, -1.453f);
       
        }
    }

    public void ZoomToClocks()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(-79.79f, 6.148f, -3.448f);
           
        }
    }


    public void SetDefault()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(-77.77f, 6.064773f, 0.29f);
            needRotaton = Quaternion.Euler(0, 180, 0);
        }
    }
}
