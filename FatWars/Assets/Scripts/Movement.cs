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

    public GameObject player;

    private float lastTimeShoot = 0;

    private void Start()
    {
        if (isLocalPlayer)
        {
            mycam = Instantiate(cameraPrefab);
            mycam.GetComponent<CameraControler>().target = transform;
        }
        else
        {
            GetComponent<Movement>().enabled = false;

        }
    }



    // Update is called once per frame   
    void Update()
    {

        if (!isLocalPlayer) return;

        playerMovement();
        Rotation();

        if (Input.GetButtonDown("Fire1"))
        {
            CmdFire();
        }
    }

    void playerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
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
            Debug.Log("hit");
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            
            if(transform.localScale.x >= 2)
            {
                Mirror.NetworkServer.Destroy(gameObject);
            }
        }
    }

    [Mirror.Command]
    void CmdFire()
    {
        if (lastTimeShoot + firingSpeed <= Time.time)
        {
            lastTimeShoot = Time.time;
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Mirror.NetworkServer.Spawn(projectile);
        }   
    }

}
