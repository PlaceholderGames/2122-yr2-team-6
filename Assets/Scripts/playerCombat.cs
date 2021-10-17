using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    
    void Attack()
    {
        //Play ATK animation
        //Detect Enemies in range of the atk
        //Apply damage
        
    }

    void FixedUpdate()
    {

    }
}
