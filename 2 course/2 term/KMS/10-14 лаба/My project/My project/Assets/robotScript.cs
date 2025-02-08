using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal2");
        float verticalInput = Input.GetAxis("Vertical2");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
