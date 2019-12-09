using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private  float movementSpeed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        Rotation(); 
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

}
