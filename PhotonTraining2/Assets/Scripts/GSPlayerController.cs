using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSPlayerController : MonoBehaviour
{
    // Public Variables
    public float fSpeed;
    public float fJumpSpeed;

    // Private Variables
    private float fXpos;
    private Rigidbody2D rbPlayerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // Setup the rigid body
        rbPlayerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for X Value and set the X Postion accordingly
        fXpos = Input.GetAxis("Horizontal");

        // Transform the player based on this horizontal movement
        gameObject.transform.position += (Vector3)new Vector2(fXpos * fSpeed * Time.deltaTime, 0.0f);
    }

    // Fixed Update - Used best for Physics Interactions
    private void FixedUpdate()
    {
        // Detect jump button
        if (Input.GetButton("Jump"))
        {
            // Do the jump
            rbPlayerRigidBody.AddForce(fJumpSpeed * transform.up, ForceMode2D.Impulse);

        }
    }
}
