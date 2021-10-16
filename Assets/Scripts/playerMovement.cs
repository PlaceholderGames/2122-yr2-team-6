using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed=40f;

    float HorizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        //Defining movement
         HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
    }
    
    void FixedUpdate()
    {
        // Actually moving               Ensure mov is the same amount regardless of multiple calls
        //                                                     Crouch Jump
        controller.Move(HorizontalMove * Time.fixedDeltaTime, false, false);
        
    }
}
