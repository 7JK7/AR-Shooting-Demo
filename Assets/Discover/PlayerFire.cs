using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    public Gun gun;
    public GameObject bulletParticle;

    public Camera xrCam;

    public AudioSource playShot;

    // Start is called before the first frame update
    void Start()
    {
        playShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFire(InputValue input)
    {
        gun.Fire();

        RaycastHit hit;
         
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if(Physics.Raycast(ray, out hit))
        {
            GameObject temp = Instantiate(bulletParticle, hit.point, Quaternion.identity);
            temp.transform.LookAt(Camera.main.transform);

            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<DronController>().Hit();
            }
        }
    }

    public void OnFire()
    {
        playShot.Play();

        gun.Fire();

        RaycastHit hit;

        Ray ray = xrCam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit))
        {
            GameObject temp = Instantiate(bulletParticle, hit.point, Quaternion.identity);
            temp.transform.LookAt(Camera.main.transform);

            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<DronController>().Hit();
            }
        }
    }
}
