using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Vector3 dir = Vector3.zero;

    public float speed = 50;
    public float jumpSpeed = 10;
    public float gravity = 20;

    public float playerHeight;
    public float jumpForce;
    public LayerMask ground;
    bool grounded;

    private KeyCode jump = KeyCode.Space;

    Rigidbody rb;
    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 1.1f, ground);

        if(Input.GetKey(KeyCode.W)) // Move forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S)) // Move backward
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A)) // Move ledt
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D)) // Move right
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(jump) && grounded) // jump if grounded
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}