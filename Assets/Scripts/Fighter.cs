using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fighter : MonoBehaviour
{
    private float fighterHealth = 400f;
    private float fighterDamage = 50f;
    public float knockbackFactor = 10f;
    public NavMeshAgent enemy;
    public Transform Stratocaster;

    void Awake()
    {
        this.GetComponent<HealthSystem>().setHealth(fighterHealth);
    }

    void Update()
    {
        enemy.SetDestination(Stratocaster.position);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Contains("Player"))
        {
            
            col.gameObject.GetComponent<HealthSystem>().doDamage(fighterDamage);
            col.gameObject.GetComponent<ImpactReceiver>().AddImpact(col.gameObject.transform.position - transform.position, knockbackFactor);
        }
    }

    }
