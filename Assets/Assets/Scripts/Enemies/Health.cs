using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int arrowDamage;
    public int spellDamage;
    int currentHealth;
    HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Arrow" && !other.gameObject.GetComponent<SelfDestruct>().hit)
        {
            TakeDamage(arrowDamage);
            other.gameObject.GetComponent<SelfDestruct>().hit = true;
            other.gameObject.transform.parent = this.gameObject.transform;
            other.rigidbody.bodyType = RigidbodyType2D.Kinematic;
            other.rigidbody.simulated = false;
            
        }
        if (other.collider.tag == "Spell")
        {
            TakeDamage(spellDamage);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage >= currentHealth)
        {
            currentHealth -= damage;
            Death();
        }
        else
        {
            currentHealth -= damage;
        }
        float healthPercentage = (float)currentHealth / (float)maxHealth;
        healthBar.UpdateBar(healthPercentage);
    }

    void Death ()
    {
        currentHealth = maxHealth;
    }
}
