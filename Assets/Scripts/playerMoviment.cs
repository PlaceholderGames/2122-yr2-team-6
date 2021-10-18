using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoviment : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed=40f;

    float horizontalMove = 0f;

    bool jump = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // Actually moving               Ensure mov is the same amount regardless of multiple calls
        //                                                     Crouch Jump
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}