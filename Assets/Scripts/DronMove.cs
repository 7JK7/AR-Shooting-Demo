using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronMove : MonoBehaviour
{
    GameObject Player;
    bool isMove = false;
    float speed = 5;

    public GameObject leftFirePoint;
    public GameObject rightFirePoint;

    AudioSource moveSound;
    public AudioClip hover;

    // Start is called before the first frame update
    void Start()
    {
        moveSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) < 2)
            {
                //Atteck
                DronFire[] fire = GetComponentsInChildren<DronFire>();
                foreach (var item in fire)
                {
                    item.Atteck(Player);
                }

                moveSound.clip = hover;
                moveSound.Play();
            }
            else
            {
                DronFire[] fire = GetComponentsInChildren<DronFire>();
                foreach (var item in fire)
                {
                    item.AtteckCancle();
                }

                transform.LookAt(Player.transform);
                transform.Translate(transform.forward * speed * Time.deltaTime);
            }
        }
    }

    public void Die()
    {
        DronFire[] fire = GetComponentsInChildren<DronFire>();
        foreach (var item in fire)
        {
            item.AtteckCancle();
        }
    }

    public void SetDron(GameObject player)
    {
        isMove = true;
        Player = player;
        transform.LookAt(Player.transform);
    }

    public void MoveStop()
    {
        isMove = false;
    }
}
