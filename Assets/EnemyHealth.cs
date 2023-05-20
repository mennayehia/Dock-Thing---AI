using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    int currentHealth;

    Animator animator;

    private void Start()
    {

        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("take damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.Play("Death");
        Debug.Log("Die");
        Destroy(this);
    }
}
