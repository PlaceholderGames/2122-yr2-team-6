using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
    private void Awake()
    {
        currentHealth = startingHealth;
    }
    
    private void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth>0)
        {
            //damage player
        }
        else
        {
            //player defeated
        }
    }
}
