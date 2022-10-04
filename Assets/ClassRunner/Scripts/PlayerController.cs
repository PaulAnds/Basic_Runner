using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     // A reference to the Rigidbody component 
    private Rigidbody rb;
    
    [Tooltip("How fast the ball moves left/right")]
    [Range(0, 10)]
    public float dodgeSpeed = 8;
    
    [Tooltip("How fast the ball moves forwards automatically")]
    [Range(0, 10)]
    public float rollSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Get access to our Rigidbody component 
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// FixedUpdate is called at a fixed framerate and is a prime place to put
    /// Anything based on time.
    /// </summary>
    private void FixedUpdate()
    {
        // Check if we're moving to the side 
       // var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;
        rb.AddForce(0, 0, rollSpeed);
    }

    private void Update()
    {
        if (transform.position.x < 1f && transform.position.x > -1f && Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(1.7f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < 1f && Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 1f && Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < 1f && transform.position.x > -1f && Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(-1.7f, transform.position.y, transform.position.z);
        }
    }
}