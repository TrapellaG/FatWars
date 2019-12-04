using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public CharacterController character; 

    void OnCollisionEnter(Collision collision)
    {
        //Destroy this gameobject
        if(collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "player")
        {
            //Physics.IgnoreCollision(character.GetComponent<Collider>(), collision.collider);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
