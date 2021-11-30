using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWN_MANAGER : MonoBehaviour
{
    //QUE ES EL OBJETO Y CUANDO APARECERA
    public GameObject bombPrefab;
    public PLAYER_CONTROLLER playerControllerScript;
    private Vector3 spawnPos;
    private int start = 1;

    //CUANTAS VECES SE REPETIRAN
    private float repeatBomb = 2f;

    //INFO PARA QUE EL ORDEN DE LOS OBJETOS SEA RANDOM EN EL EJE "Y" Y EN LA DERECHA O IZQUIERDA
    private float randomY;
    private float randomX;
    private int left = 0;
    private int right = 1;
    private Quaternion rotateObject = Quaternion.Euler(0, 180, 0);

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PLAYER_CONTROLLER>();
        InvokeRepeating("Spawner", start, repeatBomb);

    }

    private void Spawner() 
    {
        //EL OBJETO APARECERA ALEATORIAMENTE EN "Y" Y EN LA DERECHA O IZQUEIRDA
        if (!playerControllerScript.gameOver)
        {
            randomY = Random.Range(2, 14);
            randomX = Random.Range(0, 2);

            //EL OBJETO APARECERA EN LA IZQUIERDA
            if (randomX == left)
            {
                spawnPos = new Vector3(-13, randomY, 0);
                Instantiate(bombPrefab, spawnPos, bombPrefab.transform.rotation);
            }
            //EN CASO DE APARECER EN LA DERECHA, SE ROTARAN PARA QUE PAREZCA QUE VAN HACIA LA IZQUIERDA
            if (randomX == right)
            {
                spawnPos = new Vector3(13, randomY, 0);
                Instantiate(bombPrefab, spawnPos, bombPrefab.transform.rotation * rotateObject);
            }

            Instantiate(bombPrefab, spawnPos, bombPrefab.transform.rotation);
        }
    }
}
