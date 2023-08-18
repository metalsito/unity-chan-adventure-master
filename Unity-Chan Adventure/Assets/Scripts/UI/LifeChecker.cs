using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeChecker : MonoBehaviour
{
    public Image lifeIMG;
    PlayerStatus lifePlayer;
    public int lifeActive;

	// Use this for initialization
	void Start ()
    {
        lifePlayer = FindObjectOfType<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        LifeCheck();
	}

    void LifeCheck()
    {
        if (lifePlayer == null) return;

        if(lifePlayer.currentLife < lifeActive)
        {
            lifeIMG.color = Color.black;
        }

        if(lifePlayer.currentLife >= lifeActive)
        {
            lifeIMG.color = Color.red;
        }
    }
}
