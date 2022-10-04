using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    void Update()
    {
        if(transform.position.x < 0.0f && Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x == 0.0f && Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(0.8f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 0.0f && Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x == 0.0f && Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(-0.8f, transform.position.y, transform.position.z);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstaculo")
        {
            Destroy(gameObject);
        }
    }
}
