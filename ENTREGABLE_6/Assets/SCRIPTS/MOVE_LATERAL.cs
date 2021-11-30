using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE_LATERAL : MonoBehaviour
{
    
    //LA VELOCIDAD DE LOS OBJETOS Y SU LIMITE PARA DESAPARECER
    public float speed = 3f;
    public PLAYER_CONTROLLER playerControllerScript;
    private float limX = 20f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PLAYER_CONTROLLER>(); 
    }

    void Update()
    {
        //LOS OBJETOS SE MOVERAN HACIA LA DERECHA
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= limX || transform.position.x <= -limX)
            {
                Destroy(gameObject);

            }
        }
        else { Destroy(gameObject);
        }
    }
    
}
