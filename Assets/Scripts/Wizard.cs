using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wizard : MonoBehaviour
{
    public float wizardHealth = 200;
    public NavMeshAgent enemy;
    public Transform Stratocaster;
    public LayerMask _ground, _player;
    public float attackTimer;
    public float attackR;
    public bool playerInAR;
    public GameObject projectile;
    public float projectileSpe = 30;
    public float fireRate = 1;
    private float timeTillFire;
    public Transform WandHand;
    private Vector3 destination;

    private void Awake()
    {
        this.GetComponent<HealthSystem>().setHealth(wizardHealth);
        Stratocaster = GameObject.Find("Stratocaster").transform;
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInAR = Physics.CheckSphere(transform.position, attackR, _player);

        if (playerInAR)
        {
            transform.LookAt(Stratocaster);
            enemy.SetDestination(Stratocaster.position);
            
            if(Time.time >= timeTillFire)
            {
                timeTillFire = Time.time + 1 / fireRate;
                CastFireball();
            }
        }
        else
        {
            enemy.SetDestination(Stratocaster.position);
        }
    }
    
    private void CastFireball()
    {
        
        ShootProjectile();
    }

    void ShootProjectile()
    {
        Ray ray = new Ray(WandHand.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        InstantiateProjectile(WandHand);
    }
    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpe;
    }
}
