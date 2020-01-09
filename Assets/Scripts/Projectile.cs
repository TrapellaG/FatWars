using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
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
        Destroy(gameObject, 3);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "burger")
        {
             Physics.IgnoreLayerCollision(this.gameObject.layer, col.gameObject.layer = 11);
        }

       Destroy(gameObject);
    }

    void MoveProjectile()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

}
