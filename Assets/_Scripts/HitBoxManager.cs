using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour {

   public float damageAmount = 10;

    public void  OnTriggerEnter(Collider other)
    {
        HealthController objectHealth = other.GetComponent<HealthController>();

        if (objectHealth != null && other.CompareTag("Player"))
        {
            
            objectHealth.TakeDamage(damageAmount);
        }
    }
}
