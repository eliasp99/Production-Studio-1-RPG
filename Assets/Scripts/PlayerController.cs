using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController playerController;

    public float moveSpeed = 5f;
    public float rotateSpeed = 20f;


    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    { 
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), (0), Input.GetAxis("Vertical"));
        
        playerController.Move(move * Time.deltaTime * moveSpeed);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (moveDirection.magnitude < 0.1f)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        if (horizontalInput != 0)
        {
            float rotationAngle = horizontalInput * rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAngle);
        }
    }
}

