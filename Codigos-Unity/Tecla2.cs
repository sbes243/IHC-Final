using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla2 : MonoBehaviour
{
    private float moveSpeed = 5.0f; // Adjust this speed as needed

    private void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey("i"))
        {
            verticalInput = 1.0f;
        }
        else if (Input.GetKey("k"))
        {
            verticalInput = -1.0f;
        }

        if (Input.GetKey("j"))
        {
            horizontalInput = -1.0f;
        }
        else if (Input.GetKey("l"))
        {
            horizontalInput = 1.0f;
        }

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
