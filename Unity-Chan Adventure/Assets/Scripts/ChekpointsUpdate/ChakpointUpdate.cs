using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChakpointUpdate : MonoBehaviour
{
    public Transform checkpointpisition;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager checkpoint = FindObjectOfType<GameManager>();
            checkpoint.chekPoints = checkpointpisition;
        }
    }
}
