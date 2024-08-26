using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronController : MonoBehaviour
{
    public int MaxHP;
    public int currentHP;

    public GameObject ExprotionEffect;
    public GameObject Dron;

    private void Awake()
    {
        currentHP = MaxHP;
    }

    public void Hit()
    {
        currentHP--;
        if (currentHP <= 0)
        {
            Die();
            GetComponent<DronMove>().MoveStop();
        }
    }    

    void Die()
    {
        GetComponent<DronMove>().Die();
        ExprotionEffect.SetActive(true);
        Dron.SetActive(false);
    }
}
