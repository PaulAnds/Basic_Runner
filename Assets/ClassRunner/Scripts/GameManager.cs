using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("Reference to the obstacle")]
    public Transform obstacle;

    [Tooltip("A reference to the tile we want to spawn")]
    public Transform tile;

    [Tooltip("Where the first tile should be placed at")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("How many tiles should we create in advance")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    [Tooltip("How many tiles before the first obstacle")]
    public int initNoObstacles = 4;

    /// <summary> 
    /// Where the next tile should be spawned at. 
    /// </summary> 
    private Vector3 nextTileLocation;
    /// <summary> 
    /// How should the next tile be rotated? 
    /// </summary> 
    private Quaternion nextTileRotation;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>

    private void Start()
    {
        // Set our starting point 
        // Manage Rotation and Orientation
        //la locacion de la siguiente tile del camino aparece en este lugar
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;
        for (int i = 0; i < initSpawnNum; ++i)
        {
            //la i son los tiles que pasan antes de que aparescan obstaculos
            // si pones initNoObstacles = 5 cuando la i sea 6 entonces empezaran a salir obstaculos
            SpawnNextTile(i >= initNoObstacles);
        }
    }

    /// <summary> 
    /// Will spawn a tile at a certain location and setup the next
    /// position 
    /// </summary> 
    /// checa si ya paso los tiles que se spawnearon en avansado
    public void SpawnNextTile(bool spawnObstacles = true)
    {
        //instansea un tile vacio
        var newTile = Instantiate(tile, nextTileLocation,
        nextTileRotation);

        // Figure out where and at what rotation we should spawn
        // the next item 
        //busca ahora donde estas el nuevo spawnpoint que acaba de aparecer y lo pone como donde va apareceer el siguiente tile
        var nextTile = newTile.Find("Next Spawn Point");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;

        //cuando el initnoobstacles sea mayor que la i entonces llama la funcion de spawnobstacles
        //se sigue llamando infinitamente 
        if (spawnObstacles)
        {
            SpawnObstacle(newTile);
        }
    }

    //toma referencia de el tile vacio nuevo que va a aparecer
    void SpawnObstacle(Transform newTile)
    {
        //un arreglo de los spawnpoints que hay, ejemplo hay 3
        var obstaclesSpawnPoints = new List<GameObject>();

        //va a revisar todos los childs que tiene el tile
        foreach (Transform child in newTile)
        {
            //si hay un tag de obstaclespawn ahi va agregar el obstaculo como hijo
            if (child.CompareTag("ObstacleSpawn"))
            {
                //agrega un hijo al los spawnpoint que estan hijos del newtile
                obstaclesSpawnPoints.Add(child.gameObject);
            }
        }

        //si hay minimo un spawnpoint se llama esta funcion
        if (obstaclesSpawnPoints.Count > 0)
        {
            //hace que spawnpoint se elija de 1 de los 3 que hay en este ejemplo
            //                                                      //cuantos spawnpoints hay
            var spawnPoint = obstaclesSpawnPoints[Random.Range(0, obstaclesSpawnPoints.Count)];
            //agarra la posicion de el spawnpoint elejido del random arriba
            var spawnPos = spawnPoint.transform.position;
            //instancea el obstaculo en la posicion que elijio el random hace 2 lineas
            var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

            //poner el papa del obstaculo que creaste como el spawnpoint elejido
            newObstacle.SetParent(spawnPoint.transform);
        }
    }
}