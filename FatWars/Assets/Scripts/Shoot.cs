using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
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

        if(Input.GetButtonDown("Fire1"))
        {
            if (lastTimeShoot + firingSpeed <= Time.time)
            {
                lastTimeShoot = Time.time;
                ShootProjectile();
            }        
        }
             
    }

    void ShootProjectile()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}

