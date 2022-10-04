using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SPAWNER : MonoBehaviour
{

    [Header("Asignacion de enemigos")]
    public GameObject obstacle;//GO de nave enemiga

    [Header("Timer de Generacion")]
    public float timer = 2f;//tiempo de aparicion de enemigos
    private void Start()
    {
        //invocacion de funcion para generar enemigos
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies()
    {
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            Instantiate(obstacle, new Vector3(0.8f,27,37), Quaternion.Euler(-30f, 0f, 0f));
        }
        else if (random == 1)
        {
            Instantiate(obstacle, new Vector3(0.0f, 27, 37), Quaternion.Euler(-30f, 0f, 0f));
        }
        else
        {
            Instantiate(obstacle, new Vector3(-0.8f, 27, 37), Quaternion.Euler(-30f, 0f, 0f));
        }

        Invoke("SpawnEnemies", timer);
    }
}
