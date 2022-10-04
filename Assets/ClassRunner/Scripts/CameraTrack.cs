using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [Tooltip("What object should the camera be looking at")]
    public Transform target;
    [Tooltip("How offset will the camera be to the target")]
    public Vector3 offset = new Vector3(0, 3, -6);

    public bool remover = false;

    /// <summary> 
    /// Update is called once per frame 
    /// </summary> 
    private void Update()
    {
        if (remover && target != null)
        { 
            // Set our position to an offset of our target 
            transform.position = new Vector3(0, 1.5f, target.position.z - 6);
        }
        // Check if target is a valid object 
        else if (target != null)
        {
            // Set our position to an offset of our target 
            transform.position = target.position + offset;
            // Change the rotation to face target
            transform.LookAt(target);
        }
        
    }
}
