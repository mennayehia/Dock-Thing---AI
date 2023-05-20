using System.Collections;
using System.Collections.Generic;
using BBUnity.Actions;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    Animator animator;
   
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("take damage");
        animator.Play("TakeDamage");

        if (currentHealth <= 0)
        {
            Debug.Log("Enemy died");

            Die();
        }
    }

    public void Die()
    {
        if(animator != null)
        {
            animator.SetTrigger("Death");

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("playerhealth");
            PlayerHealth PH = other.gameObject.GetComponent<PlayerHealth>();
            PH.TakeDamage(25);
        }
    }

}
