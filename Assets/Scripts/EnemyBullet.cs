using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject Player;

    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerFire>().gameObject;

        if(Player != null)
            transform.LookAt(Player.transform.GetChild(1));

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,0.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameObject temp = Instantiate(particle, collision.contacts[0].point, Quaternion.identity);
            Vector3 target = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);

            temp.transform.LookAt(target);
            temp.transform.Rotate(0, 180, 0);

            temp.transform.SetParent(Player.transform);
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        //Instantiate(particle, other.ClosestPoint(), Quaternion.identity);
    //    }
    //}
}
