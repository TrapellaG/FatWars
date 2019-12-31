using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player3 : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 6.0f;

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
    public float pushed = 300;
    int pushCount = 0;
    public bool move = true;
    public float moveCooldown;

    float xAxis;
    float yAxis;

    private void Start()
    {
        pushLVL = "pushLVL1";
    }



    // Update is called once per frame   
    void Update()
    {
        if (move == true)
        {
            playerMovement();
            Rotation();
        }

        dashTime -= Time.smoothDeltaTime;
        pushcooldown -= Time.smoothDeltaTime;

        if (pushcooldown <= 0)
        {
            pushactive = true;
        }

        if (Input.GetButtonDown("Fire1Player3"))
        {
            CmdFire();
        }

        if (Input.GetButtonDown("Fire3"))
        {
            if (pushactive == true)
            {
                pushcooldown = 2f;
                Push();
            }
        }

        if (move == false)
        {
            moveCooldown -= Time.smoothDeltaTime;
        }
        if (moveCooldown <= 0)
        {
            move = true;
            moveCooldown = 2f;
        }

        if (dash == true)
        {
            dash = false;
            pushactive = false;

        }

        if (dashTime <= 0)
        {
            this.gameObject.tag = "player3";
        }

        if (this.transform.position.y <= -5)
        {
            Destroy(gameObject);
        }

    }

    void playerMovement()
    {
        float horizontal = Input.GetAxis("HorizontalPlayer3");
        float vertical = Input.GetAxis("VerticalPlayer3");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }


    void Rotation()
    {
        if (Mathf.Abs(Input.GetAxis("HorizontalPlayer3")) >= joystickDeadzone || Mathf.Abs(Input.GetAxis("VerticalPlayer3")) >= joystickDeadzone)
        {
            xAxis = Input.GetAxis("HorizontalPlayer3");
            yAxis = Input.GetAxis("VerticalPlayer3");
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

        float horizontal = Input.GetAxis("HorizontalPlayer3");
        float vertical = Input.GetAxis("VerticalPlayer3");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        this.GetComponent<Rigidbody>().AddForce(movement * force);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            Debug.Log("hit");
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            force += 200;
            pushCount++;

            if (pushCount == 1)
            {
                pushLVL = "pushLVL2";
            }
            if (pushCount == 2)
            {
                pushLVL = "pushLVL3";
            }
            if (pushCount == 3)
            {
                pushLVL = "pushLVL4";
            }

            if (transform.localScale.x >= 2)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "pushLVL1" || collision.gameObject.tag == "pushLVL2" || collision.gameObject.tag == "pushLVL3" || collision.gameObject.tag == "pushLVL4")
        {
            move = false;

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

            float horizontal = Input.GetAxis("HorizontalPlayer3");
            float vertical = Input.GetAxis("VerticalPlayer3");

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
