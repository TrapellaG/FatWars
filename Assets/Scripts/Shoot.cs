using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Mirror.NetworkBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float firingSpeed;

    private float lastTimeShoot = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        if(Input.GetButtonDown("Fire1"))
        {
            if (lastTimeShoot + firingSpeed <= Time.time)
            {
                lastTimeShoot = Time.time;
                ShootProjectile();
            }        
        }
             
    }

    [Mirror.Command]
    void ShootProjectile()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        Mirror.NetworkServer.Spawn(projectile);
    }
}

