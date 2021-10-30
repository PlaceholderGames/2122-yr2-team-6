using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public Transform rayCast;
    public LayerMask raycastMAsk;
    public float rayCastLength;
    public float attackDistance; // Minimum distance for attack
    public float moveSpeed;
    public float timer; // Timer for cooldown between attacks

    int currentHealth;
    private RaycastHit2D Hit;
    private GameObject target;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool inRange; // Check if Player is in range
    private bool cooling; // Check if enemy is cooling after attack
    private float intTimer;


    // Start is called before the first frame update


    void Start()
    {
        intTimer = timer; // Store the value of timer
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (inRange)
        {
            Hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMAsk);
            RaycastDebugger();
        }
        //When Player is detected
        if (Hit.collider != null)
        {
            EnemyLogic();
        }
        else if (Hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            animator.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Die animation
        animator.SetBool("isDead", true);
        //Disable his collider
        GetComponent<Collider2D>().enabled = false;

        //Disable the enemy
        this.enabled = false;
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            animator.SetBool("Attack", false);
        }
    }

    void Move()
    {
        animator.SetBool("canWalk", true);

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("bigguy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; //Reset Timer when Player enters Attack Range
        attackMode = true; //To check if Enemy can still attack or not

        animator.SetBool("canWalk", false);
        animator.SetBool("Attack", true);
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }
}
