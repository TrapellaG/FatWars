using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burger : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 2, 0, Space.Self);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 11)
        {
            Destroy(collision.gameObject);
            Debug.Log("burger destroyed");
        }
    }
}
