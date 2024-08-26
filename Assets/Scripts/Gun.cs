using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] bullet;
    public GameObject[] Effect;
    int currentIDX=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Fire()
    {
        Shot();
    }

    void Shot()
    {
        bullet[currentIDX].SetActive(true);
        Effect[currentIDX].SetActive(true);
        currentIDX++;
        if (currentIDX >= bullet.Length)
            currentIDX = 0;
    }
}
