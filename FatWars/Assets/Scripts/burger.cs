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
}
