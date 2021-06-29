using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float spellDamage = 25f;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Contains("|Enemy|") || col.gameObject.tag.Contains("Player"))
        {
            col.gameObject.GetComponent<HealthSystem>().doDamage(spellDamage);
        }
        Destroy(gameObject);
    }
}
