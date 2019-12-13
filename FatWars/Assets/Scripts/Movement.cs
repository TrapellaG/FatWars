using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : Mirror.NetworkBehaviour
{
    [SerializeField]
    private  float movementSpeed = 6.0f;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    float firingSpeed;

    private Camera mycam;

    public Camera cameraPrefab;

    private float lastTimeShoot = 0;

    private void Awake()
    {
        mycam = Instantiate(cameraPrefab);
        mycam.GetComponent<CameraControler>().target = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer) return;

        playerMovement();
        Rotation();

        if (Input.GetButtonDown("Fire1"))
        {
            fire();
        }
    }

    void playerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        
    }

    void Rotation()
    {
        RaycastHit hit;
        Ray ray = mycam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    [Mirror.ServerCallback]
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

            if(transform.localScale.x >= 2)
            {
                Mirror.NetworkServer.Destroy(gameObject);
            }
        }
    }

    [Mirror.Command]
    void fire()
    {
        if (lastTimeShoot + firingSpeed <= Time.time)
        {
            lastTimeShoot = Time.time;
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Mirror.NetworkServer.Spawn(projectile);
    }

}
