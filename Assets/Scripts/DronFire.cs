using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Effect;
    public GameObject Tracer;

    GameObject Player;

    float AtteckTimer;
    float AtteckRate = 1;
    bool isAtteck = false;

    public AudioSource atteck;

    private void Update()
    {
        if(isAtteck)
        {
            AtteckTimer += Time.deltaTime;
            if(AtteckTimer > AtteckRate)
            {
                AtteckTimer = 0;
                _Atteck();
            }
        }
    }

    private void _Atteck()
    {
        atteck.Play();

        GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
        temp.SetActive(true);
        temp.GetComponent<EnemyBullet>().Player = Player;

        Effect.transform.LookAt(Player.transform);
        Tracer.transform.LookAt(Player.transform);


        Effect.SetActive(true);
        Tracer.SetActive(true);
    }

    public void Atteck(GameObject player)
    {
        
        if(Player == null)
         Player = player;

        isAtteck = true;
    }

    public void AtteckCancle()
    {
        isAtteck = false;
        AtteckTimer = 0;
    }
}
