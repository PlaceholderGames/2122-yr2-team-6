using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoviment : MonoBehaviour
{

    public Rigidbody2D rb;

    public float speed;
    
    public float jumpForce;

    private float moveInput;

    private bool isGrounded;

    public Transform feetPos;

    public float checkRadius;

    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    
    public float jumpTime;

    public bool isJumping;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }    
    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (moveInput == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("takeOf");
            isJumping = true;
            jumpTimeCounter = jumpTime; 
            rb.velocity = Vector2.up * jumpForce;
        }

        if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        if(Input.GetKey(KeyCode.Space) && isJumping==true)
        { 
            if(jumpTimeCounter>0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter-=Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
        }
    }
}
