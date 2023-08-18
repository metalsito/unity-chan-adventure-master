using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform radiusDetector, shootPoint;
    public GameObject bullet;
    public LayerMask player;
    public float radius;
    public bool lookPlayer;
	
	void Update ()
    {
        LookPlayerTrue();
        LookToPlayer();
	}

    void LookPlayerTrue()
    {
        lookPlayer = Physics.CheckSphere(radiusDetector.position, radius, player);
    }

    void LookToPlayer()
    {
        if(lookPlayer == true)
        {
            PlayerStatus player = FindObjectOfType<PlayerStatus>();
            transform.LookAt(player.transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(radiusDetector.position, radius);
    }

    IEnumerator ShootingPlayer()
    {
        Instantiate(bullet, shootPoint);
        yield return null;
    }
}
