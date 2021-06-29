using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rogue : MonoBehaviour
{
    private static Rogue _instance;
    public static Rogue Instance {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Rogue is null");
            }
            return _instance;
        }
    }

    public NavMeshAgent enemy;
    public Transform Treasure;
    public Transform Portal;
    public bool hasTreasure;

    [SerializeField]
    private float rogueHealth = 200f;

    public bool QueryTreasure() {
        return hasTreasure; 
    }

    public void CollectTreasure() { 
        hasTreasure = true; 
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Portal")
        {
            //Todo end game
        }
    }

    void Awake() 
    {
        _instance = this;
        this.GetComponent<HealthSystem>().setHealth(rogueHealth);
    }

    void Update()
    {
        if (hasTreasure == true)
        {
            enemy.SetDestination(Portal.position);
        }

        else
        {
            enemy.SetDestination(Treasure.position);
        }
    }
}