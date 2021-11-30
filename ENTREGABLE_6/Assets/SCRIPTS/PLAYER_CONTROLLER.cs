using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_CONTROLLER : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    //MODIFICA LA GRAVEDAD Y LIMITES
    private float jumpForce = 5f;
    private float gravityMod = 0.7f;
    private float limY = 14f;

    //GAMEOVER
    public bool gameOver;

    //MUSICA Y EFECTOS DE SONIDO
    private AudioSource playerAudioSource;
    public AudioClip colisionClip;
    public AudioClip jumpClip;

    //PARTICULAS
    public ParticleSystem explosion;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityMod;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && transform.position.y <= 13f)
        {
            //CUANDO SE SALTA, SE REALIZA UN IMPULSO HACIA ARRIBA
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudioSource.PlayOneShot(jumpClip, 3);
        }

        if (transform.position.y >= limY)
        {
            //SOLO PODEMOS SALTAR HASTA EL LIMITE Y
            transform.position = new Vector3(transform.position.x, limY, transform.position.z);

        }
    }


    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {   //CUANDO CHOCA CON EL SUELO
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                //COMUNICAMOS QUE HEMOS MUERTO (GAMEOVER)
                Debug.Log("GameOver");
                gameOver = true;
                Destroy(gameObject);
            }

            //CUANDO CHOCA CON LOS OBJETOS LLAMADOS OBSTACLE
            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                //COMUNICAMOS QUE HEMOS MUERTO (GAMEOVER)
                gameOver = true;
                Debug.Log("GameOver");
                Destroy(gameObject);

                //SE REALIZA UNA ANIMACION DE PARTCULAS
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);

                //EFECTO DE SONIDO DE PARTICULAS
                playerAudioSource.PlayOneShot(colisionClip, 3);
            }

            else
            {
                //LA MUSICA SE DETIENE CUANDO EL JUEGO SE ACABA
                playerAudioSource.Stop();
            } 
        }
    }
}
