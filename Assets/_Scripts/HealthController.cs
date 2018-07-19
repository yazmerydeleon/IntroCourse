using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private float currentHealth;
    public float maxHealth;
    public float healthRegenSpeed;
    public float damageTimer;
    private float currentDamageTimer;

    public Image healthBar;

    public void TakeDamage(float damageAmount)
    {
        currentHealth = Mathf.Max(0, currentHealth - damageAmount);
        currentDamageTimer = damageTimer;
        Debug.Log("DAMAGE! " + name + ". currentHealth: " + currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void HealthGen()
    {
        if (currentDamageTimer == 0)
        {
            currentHealth = Mathf.Min(maxHealth, currentHealth + healthRegenSpeed * Time.deltaTime);
            if (currentHealth < maxHealth)
            {
                //Debug.Log("Regen: " + currentHealth);
            }
        }
        else
        {
            currentDamageTimer = Mathf.Max(0, currentDamageTimer - Time.deltaTime);
            //Debug.Log("currentDamageTimer: " + currentDamageTimer);
        }
    }

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthGen();

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

}
