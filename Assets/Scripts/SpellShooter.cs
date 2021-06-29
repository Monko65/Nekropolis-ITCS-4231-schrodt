using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform LeftFireP, RightFireP;
    public float projectileSpe = 30;
    public float fireRate = 1;

    private Vector3 destination;
    private bool leftHand;
    private float timeTillFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= timeTillFire)
        {
            timeTillFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        if (leftHand)
        {
            leftHand = false;
            InstantiateProjectile(LeftFireP);
        }
        else
        {
            leftHand = true;
            InstantiateProjectile(RightFireP);
        }

    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpe;
    }
}
