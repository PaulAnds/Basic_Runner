using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    [Header("The Prefab of the wall that will be instanciated")]
    public GameObject Wall;
    [Header("The time the last tile will be removed")]
    public float timeToDestroy = 3f;


    private Vector3 nextPosition;
    private bool spawn;

    void Start()
    {//makes spawn true in order to get into de trigger to spawn the next one
        spawn = true;
    }
    private void Update()
    {
        if (!spawn){//Destroying the las tile
            //Destroy(gameObject, timeToDestroy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && spawn){//when player gets to the trigger spawn next tile once
            nextPosition = new Vector3(transform.position.x, transform.position.y + 15.54f, transform.position.z);
            Instantiate(Wall, nextPosition, transform.rotation);
            spawn = false;
        }
    }
}
