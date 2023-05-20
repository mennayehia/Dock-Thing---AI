using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 25;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dummie")
        {
            other.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("collision with enemy");
        }
    }
}
