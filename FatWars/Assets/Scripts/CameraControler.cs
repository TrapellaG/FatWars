using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField]
    public Transform target;
    [SerializeField]
    public Vector3 targetOffset; //distance between the target and the camera
    [SerializeField]
    private float movementSpeed;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
       
        transform.position = target.position + targetOffset;// (target.position - transform.position).normalized * 5.0f;
        //target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime);
    }
}
