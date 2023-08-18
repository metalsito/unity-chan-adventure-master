using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f, jumpForce = 5f, radiusDetector = 0.2f;
    public Transform floorDetector;
    public LayerMask floorLayer;
    public bool touchingFloor;
    Rigidbody rgBody;
    Vector3 targetPos;
    Animator animator;

    void Start()
    {
        rgBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        InputMovement();
    }

    private void FixedUpdate()
    {
        rgBody.MovePosition(rgBody.position + targetPos * Time.fixedDeltaTime);
    }

    void InputMovement()
    {
        touchingFloor = Physics.CheckSphere(floorDetector.position, radiusDetector, floorLayer);
        targetPos = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Moving", true);
            targetPos += transform.forward * forwardSpeed;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localRotation = Quaternion.AngleAxis(0, Vector3.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            targetPos += transform.forward * forwardSpeed;
            animator.SetBool("Moving", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localRotation = Quaternion.AngleAxis(180, Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.Space) && touchingFloor)
        {
            rgBody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }


        if (touchingFloor == false)
        {
            animator.SetBool("Jumping", true);
        }

        if (touchingFloor == true)
        {
            animator.SetBool("Jumping", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(floorDetector.position, radiusDetector);
    }

}
