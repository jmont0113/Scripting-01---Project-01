using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;

    private Vector3 rotateVector = new Vector3(0, 1, 0);

    public float thrust = 10.0f; 
    [SerializeField] float turn = 10.0f;

    private Vector3 velocityRigidbody = new Vector3(0, 0, 0);
    private Vector3 resetDirection = new Vector3(0, 0, 0);

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        resetDirection = transform.position;
    }

    void Start()
    {
        constraints();
    }

    void FixedUpdate()
    {
        rb.angularVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * thrust);
            changeAcceleration();

        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.back * thrust);
            MovementSpeed();
        }

        if (Input.GetKey(KeyCode.D))
        {
            turn = Input.GetAxis("Horizontal");
            rb.AddRelativeTorque(Vector3.left * 1 * 1);
            rb.transform.Rotate(rotateVector * 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            turn = Input.GetAxis("Horizontal");
            rb.AddRelativeTorque(Vector3.left * - 1 * - 1);
            rb.transform.Rotate(rotateVector * - 1);
         }

        void changeAcceleration()
        {
            rb.drag = 1.5f;
            rb.angularDrag = 2.0f;
        }

        void MovementSpeed()
        {
            rb.drag = 1.0f;
            rb.angularDrag = 1.5f;
        }
    }

    public void constraints()
    {
        rb.velocity = velocityRigidbody;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
