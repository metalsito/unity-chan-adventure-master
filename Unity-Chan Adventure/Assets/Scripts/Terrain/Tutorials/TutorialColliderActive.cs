using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialColliderActive : MonoBehaviour
{
    public Text tutorial;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorial.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorial.gameObject.SetActive(false);
        }
    }
}
