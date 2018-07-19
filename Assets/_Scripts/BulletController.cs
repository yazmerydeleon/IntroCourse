using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float DamageAmount;

    public GameObject Owner;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != Owner)
        {
            Debug.Log("Hit! " + other.name);
            other.GetComponent<HealthController>().TakeDamage(DamageAmount);
            Destroy(gameObject);
        }
    }
}
