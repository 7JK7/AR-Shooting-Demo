using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;

    public Transform firePoint;

    float fireRate = 1f;
    float fireTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(fireTimer > fireRate)
        {
            fireTimer = 0;
            Instantiate(bullet, firePoint.position, Quaternion.identity);
        }
    }
}
