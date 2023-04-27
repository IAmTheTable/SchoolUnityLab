//Aiden Sanchez
// 4/25/23
// Assignment 3

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpSpeed;

    public Rigidbody playerRb;
    [SerializeField]
    private bool isGrounded;

    private Bounds planeBounds;


    // Start is called before the first frame update
    void Start()
    {
        planeBounds = GameObject.Find("Plane").GetComponent<MeshRenderer>().localBounds;
        if (playerRb == null)
            Debug.Log("rb is null");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Plane")
            isGrounded = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Plane")
            isGrounded = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        //CheckBounds();
    }
    public void CheckBounds()
    {
        // check if the player is out of the min x, z, and max x, z bounds of the plane
        if (transform.position.x < planeBounds.min.x || transform.position.z < planeBounds.min.z || transform.position.x > planeBounds.max.x || transform.position.z > planeBounds.max.z)
        {
            Debug.Log("Out of bounds");
            transform.position = new Vector3(0, 1, 0);
        }
    }

    public void Move()
    {
        // move using WASD (UP LEFT DOWN RIGHT)
        if (Input.GetKey(KeyCode.W))
        {
            playerRb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRb.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(Vector3.right * speed);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    public void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpSpeed);
    }
}
