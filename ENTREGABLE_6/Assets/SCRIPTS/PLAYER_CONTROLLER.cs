using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_CONTROLLER : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    //MODIFICA LA GRAVEDAD
    private float jumpForce = 550f;
    private float gravityMod = 1.5f;

    //SUELO Y GAMEOVER
    private bool isOnGround = true;
    public bool gameOver;

    //MUSICA Y EFECTOS DE SONIDO
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    public AudioClip colisionClip;
    public AudioClip jumpClip;

    //PARTICULAS
    public ParticleSystem particleSystem;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        Physics.gravity *= gravityMod;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //CUANDO SE SALTA, SE REALIZA UN IMPULSO HACIA ARRIBA
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");

            //CUANDO SALTA HACE SONIDO DE SALTO
            playerAudioSource.PlayOneShot(jumpClip, 1);
            isOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {

            //CUANDO CHOCA CON LOS OBJETOS LLAMADOS OBSTACLE
            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                //COMUNICAMOS QUE HEMOS MUERTO (GAMEOVER)
                gameOver = true;

                //SE REALIZA UNA ANIMACION DE PARTCULAS
                particleSystem.Play();

                //EFECTO DE SONIDO DE PARTICULAS
                playerAudioSource.PlayOneShot(explosionClip, 1);

                //COMUNICAMOS QUE HEMOS MUERTO (GAMEOVER)
                gameOver = true;

                isOnGround = false;
            }
        }
    }
}
