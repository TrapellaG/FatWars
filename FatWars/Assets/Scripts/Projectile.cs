using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Mirror.NetworkBehaviour
{
    private Vector3 firingPoint;

    [SerializeField]
    private float projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        firingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    [Mirror.Server]
    void OnCollisionEnter()
    {
        Mirror.NetworkServer.Destroy(gameObject);
    }

    void MoveProjectile()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

}
