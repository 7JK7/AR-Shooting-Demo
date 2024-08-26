using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemCollback : MonoBehaviour
{
    public bool isDron;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleSystemStopped()
    {
        if(isDron)
        {
            Destroy(transform.parent.parent.gameObject);

        }
        else
        {
            Destroy(transform.parent.gameObject);

        }
    }
}
