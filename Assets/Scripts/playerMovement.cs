using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed=40f;
    
    public Rigidbody2D rb;

    float HorizontalMove = 0f;

    
    private void Start()
    {
   
        //Defining movement
         rb = GetComponent <Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    private void Update()
    {   if (Input.GetKeyDown("space") {
            //Defining movement
            rb.velocity = new Vector3(0, 14f, 0);
        }
    }
    
    //private void FixedUpdate()
    //{
    //    // Actually moving               Ensure mov is the same amount regardless of multiple calls
    //    //                                                     Crouch Jump
    //    controller.Move(HorizontalMove * Time.fixedDeltaTime, false, false);
        
    //}
}
