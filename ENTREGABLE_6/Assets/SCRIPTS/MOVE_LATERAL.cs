using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE_LATERAL : MonoBehaviour
{

    //LA VELOCIDAD DE LOS OBJETOS SERA DE (10)
    public float speed = 10f;
    public PlayerController playerControllerScript;


    void Start()
    {
        
    }

    void Update()
    {
        //LOS OBJETOS SE MOVERAN HACIA LA IZQUIERDA
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }
}
