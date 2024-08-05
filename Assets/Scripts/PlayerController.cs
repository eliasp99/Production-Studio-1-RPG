using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController playerController;

    public float Speed = 5f;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        playerController.Move(move * Time.deltaTime * Speed);
    }
}
