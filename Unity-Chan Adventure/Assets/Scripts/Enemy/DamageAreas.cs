using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAreas : MonoBehaviour
{
    public int damage;

    private void Start()
    {
        damage = 1;
    }

    private void Update()
    {
        NodamageDead();
    }

    void NodamageDead()
    {
        EnemyWeakPoint weakPointBool = GetComponent<EnemyWeakPoint>();
        if (weakPointBool.weakPointTouched == true)
        {
            damage = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
     {
        PlayerStatus playerLife = other.gameObject.GetComponent<PlayerStatus>();
        if (other.gameObject.tag == "Player")
        {
            playerLife.currentLife -= damage;
            damage = 0;
        }
     }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            damage = 1;
        }
    }
}
