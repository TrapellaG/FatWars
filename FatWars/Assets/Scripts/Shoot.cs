using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody projectile;
    Vector3 mousePos;

    // Use this for initialization
    void Start()
    {

    }
    private void OnDrawGizmos()
    {
     
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (Input.GetMouseButtonDown(0)) //check if the LMB is clicked
            {
                RaycastHit hit;
                Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit)) //check if the ray hit something
                {
                    mousePos = hit.point; //use this position for what you want to do
                    Debug.DrawRay(hit.point, -ray.direction);
                }
            }
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = (mousePos - transform.position).normalized;//transform.TransformDirection(new Vector3(0, 0, speed));
        }
       
    }
}

