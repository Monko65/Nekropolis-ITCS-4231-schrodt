using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    protected float Health;
    protected float MaxHealth;
    protected float Damage;

    public void setHealth(float health)
    {
        Health = health;
        MaxHealth = health;
    }

    public void doDamage(float damage)
    {
        Health -= damage;
    }

    public void doHealing(float heal)
    {
        Health += heal;
    }

    public float getHealth()
    {
        return Health;
    }

    public float getMaxHealth()
    {
        return MaxHealth;
    }

    public void kill()
    {
        if (this.gameObject.tag == "Player")
        {
            // TODO End game
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Health <= 0)
        {
            kill();
        }
    }

}
