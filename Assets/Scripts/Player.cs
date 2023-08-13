using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform dinoTransform;
    private float jumpForce = 5f;
    private float gravity = -9.81f;
    private float verticalVelocity = 0f;

    [SerializeField] private Vector3 vector3;
    [SerializeField] private float moveDino;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        } 
        
        // Simulate gravity
        verticalVelocity += gravity * Time.deltaTime;
        
        // Update the dino's vertical position
        dinoTransform.position += new Vector3(0f, verticalVelocity * Time.deltaTime, 0f);

        if (dinoTransform.position.y <= 0.76)
        {
            dinoTransform.position = new Vector3(dinoTransform.position.x, 0.76f, dinoTransform.position.z);
            verticalVelocity = 0f;
        }
    }
}
