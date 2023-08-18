using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakPoint : MonoBehaviour
{
    public Transform weakPointDetector;
    public bool weakPointTouched = false;
    public LayerMask Player;
    public float radius = 0.25f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();  
    }

    void Update ()
    {
        WeakPointTouched();
        Dead();
	}

    void WeakPointTouched()
    {
        weakPointTouched = Physics.CheckSphere(weakPointDetector.position, radius, Player);
    }
    void Dead()
    {
        if(weakPointTouched == true)
        {
            //animator.SetBool("Dead", true);
            //gameObject.SetActive(false);
            StartCoroutine(AnimationDead());
        }
    }

    IEnumerator AnimationDead()
    {
        weakPointTouched = true;
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        yield return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(weakPointDetector.position, radius);
    }
}
