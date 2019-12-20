using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player1 : MonoBehaviour
{
    [SerializeField]
    private  float movementSpeed = 6.0f;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    float firingSpeed;

    private float lastTimeShoot = 0;
    public float rotationSpeed = 4f;
    public float joystickDeadzone = 0.2f;
    public float force = 300f;
    public bool dash = false;
    public bool pushactive = true;
    public float pushcooldown = 0;
    public string pushLVL;
    float dashTime = 1f;
    float pushed = 300;

    float xAxis;
    float yAxis;

    private void Start()
    {
        pushLVL = "pushLVL1";
    }



    // Update is called once per frame   
    void Update()
    {
        playerMovement();
        Rotation();

        dashTime -= Time.smoothDeltaTime;
        pushcooldown -= Time.smoothDeltaTime;

        if (pushcooldown <= 0)
        {
            pushactive = true;
        }

        if (Input.GetButtonDown("Fire1Player1"))
        {
            CmdFire();
        }

        if(Input.GetButtonDown("Fire3"))
        {       
            if(pushactive == true)
            {
                pushcooldown = 5f;
                Push();
            }
        }

        if(dash == true)
        {
            dash = false;
            pushactive = false;
            
        }

        if (dashTime <= 0)
        {
            this.gameObject.tag = "player1";
        }

    }

    void playerMovement()
    {
        float horizontal = Input.GetAxis("HorizontalPlayer1");
        float vertical = Input.GetAxis("VerticalPlayer1");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }


    void Rotation()
    {
        if (Mathf.Abs(Input.GetAxis("HorizontalPlayer1")) >= joystickDeadzone || Mathf.Abs(Input.GetAxis("VerticalPlayer1")) >= joystickDeadzone)
        {
            xAxis = Input.GetAxis("HorizontalPlayer1");
            yAxis = Input.GetAxis("VerticalPlayer1");
        }
        float joystickAngle = Mathf.Atan2(xAxis, yAxis) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, joystickAngle, 0), Time.deltaTime * rotationSpeed);

        /* RaycastHit hit;
         Ray ray = mycam.ScreenPointToRay(Input.mousePosition);

         if(Physics.Raycast(ray, out hit))
         {
             transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
         }*/
    }

    void Push()
    {
        dashTime = 1f;

        dash = true;
        this.gameObject.tag = "push";

        float horizontal = Input.GetAxis("HorizontalPlayer1");
        float vertical = Input.GetAxis("VerticalPlayer1");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        this.GetComponent<Rigidbody>().AddForce(movement * force);

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            Debug.Log("hit");
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            force += 200;
            
            if(transform.localScale.x >= 2)
            {
               Destroy(gameObject);
            }
        }
        
        if(collision.gameObject.tag == "push")
        {
            switch (collision.gameObject.tag)
            {
                case "pushLVL1":
                    pushed = 300;
                    break;

                case "pushLVL2":
                    pushed = 500;
                    break;

                case "pushLVL3":
                    pushed = 700;
                    break;

                case "pushLVL4":
                    pushed = 900;
                    break;

            }

            float horizontal = Input.GetAxis("HorizontalPlayer1");
            float vertical = Input.GetAxis("VerticalPlayer1");

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            this.GetComponent<Rigidbody>().AddForce(movement * pushed);
            Debug.Log("wow");
        }
    }

    void CmdFire()
    {
        if (lastTimeShoot + firingSpeed <= Time.time)
        {
            lastTimeShoot = Time.time;
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }   
    }

}
