using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maximumLife = 3, currentLife, attemps = 3;
    public bool playerDead;
	
	void Start ()
    {
        currentLife = maximumLife;
	}
	
	void Update ()
    {
        Dead();
        Alive();
	}
    
    void Dead()
    {
        if (currentLife <= 0)
        {
           playerDead = true;
        }
    }

    void Alive()
    {
        if(currentLife > 0)
        {
            playerDead = false;
        }
    }
}
