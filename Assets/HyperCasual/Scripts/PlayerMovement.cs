using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animation anim;
    private bool right;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        right = false;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !right && canJump)
        {
            anim.Play("JumpRight");
            gameObject.transform.position = new Vector3(2.599f, transform.position.y, transform.position.z);
            right = true;
            canJump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && right && canJump)
        {
            anim.Play("JumpLeft");
            gameObject.transform.position = new Vector3(-2.613f, transform.position.y, transform.position.z);
            right = false;
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Right")
        {
            canJump = true;
        }

        if(other.tag == "Left")
        {
            canJump = true;
        }
    }
}
