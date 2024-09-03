using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent rotation
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        // Get player input
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed;

        // Create a movement vector based on input
        rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
