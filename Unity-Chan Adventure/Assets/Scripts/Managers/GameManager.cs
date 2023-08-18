using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform chekPoints;
    public GameObject[] Enemies;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
        PlayerDie();
        
	}

    public void PlayerDie()
    {
        PlayerStatus playerDie = FindObjectOfType<PlayerStatus>();
        if(playerDie.playerDead == true && playerDie.attemps > 0)
        {
            StartCoroutine(ResetEnemy());
            StartCoroutine(ResetPlayer());
        }
    }

    IEnumerator ResetPlayer()
    {
        PlayerStatus playerPosition = FindObjectOfType<PlayerStatus>();
        playerPosition.transform.position = chekPoints.position;
        playerPosition.currentLife = playerPosition.maximumLife;
        playerPosition.attemps -= 1;
        yield return null;
    }

    IEnumerator ResetEnemy()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].SetActive(true);
        }
        yield return null;
    }
}
