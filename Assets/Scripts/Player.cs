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
    [SerializeField] private AnimatedScript animatedScriptRun;
    [SerializeField] private AnimatedScript animatedScriptJump;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animatedScriptJump.render = true;
            animatedScriptRun.render = false;
            verticalVelocity = jumpForce;
        } 
        
        // Simulate gravity
        verticalVelocity += gravity * Time.deltaTime;
        
        // Update the dino's vertical position
        dinoTransform.position += new Vector3(0f, verticalVelocity * 3 * Time.deltaTime, 0f);

        if (dinoTransform.position.y <= -1.66f)
        {
            animatedScriptJump.render = false;
            animatedScriptRun.render = true;
            dinoTransform.position = new Vector3(dinoTransform.position.x, -1.66f, dinoTransform.position.z);
            verticalVelocity = 0f;
        }
    }
}
