using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawner : MonoBehaviour
{
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;
    public Transform spawn9;
    public Transform spawn10;
    public Transform spawn11;
    public GameObject burgerPrefab;
    public bool spawn;
    public float spawnCooldown = 2f;

    private void Start()
    {
        spawn = true;
        spawnCooldown = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown -= Time.smoothDeltaTime;

        if(spawnCooldown <= 0)
        {
            spawn = true;
        }

        if(spawn == true)
        {
            spawnFood();
        }      
    }

    private void spawnFood()
    {
        spawn = false;
        spawnCooldown = 2f;
        float randomLocation = Random.Range(1, 11);

        if(randomLocation == 1)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn1.position, spawn1.rotation);
        }
        if(randomLocation == 2)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn2.position, spawn2.rotation);
        }
        if(randomLocation == 3)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn3.position, spawn3.rotation);
        }
        if(randomLocation == 4)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn4.position, spawn4.rotation);
        }
        if(randomLocation == 5)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn5.position, spawn5.rotation);
        }
        if(randomLocation == 6)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn6.position, spawn6.rotation);
        }
        if(randomLocation == 7)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn7.position, spawn7.rotation);
        }
        if(randomLocation == 8)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn8.position, spawn8.rotation);
        }
        if(randomLocation == 9)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn9.position, spawn9.rotation);
        }
        if(randomLocation == 10)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn10.position, spawn10.rotation);
        }
        if(randomLocation == 11)
        {
            GameObject burger = Instantiate(burgerPrefab, spawn11.position, spawn11.rotation);
        }
    }
}
