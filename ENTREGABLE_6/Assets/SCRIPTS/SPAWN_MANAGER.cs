using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWN_MANAGER : MonoBehaviour
{
    public GameObject[] bombPrefab;
    public Vector3 spawnPos = new Vector3(14, 0, 0);
    //public Vector3 spawnPos = new Vector3(-14, 0, 0);
    //public int bombPrefab;

    //AL LLGAR AL LIMITE SE ELIMINARA
    private float upperLim = 30f;
    private float lowerLim = -5f;

    //MUSICA Y SONIDO
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    public AudioClip explosionClip;
    public AudioClip jumpClip;

    void Start()
    {
        Instantiate(bombPrefabs[0], spawnPos, bombPrefabs[0].transform.rotation);

        //MUSICA Y SONIDO
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

    }


    void Update()
    {
        //SALTO (CUANDO SE TOCA LA BARRA ESPACIADORA, TOCA EL SUELO Y NO ES GAMEOVER)

        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            //CUANDO SE SALTA, SE REALIZA UN IMPULSO HACIA ARRIBA
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");


            //CUANDO NO TOCA EL SUELO, HACE VFX DE SALTO (A UN SONIDO DE 1)
            playerAudioSource.PlayOneShot(jumpClip, 1);
            isOnGround = false;

            //AL LLGAR AL LIMITE SE ELIMINARA
            if (transform.position.z > upperLim)
            {
                Destroy(gameObject);
            }
            if (transform.position.z < upperLim)
            {
                Destroy(gameObject);
            }
        }

        /*n = Random.Range(0, 2);
        if n == 0
        {
            n = -1

        }
        n* spawnPosx;
        */
    }

    //CUANDO SE COLISIONA CON EL SUELO, IS ON THE GROUND = TRUE (HAY COLISION CON EL SUELO)
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtParticleSystem.Play();
            }

            //CUANDO CHOCA CON LOS OBJETOS LLAMADOS BOMB
            if (otherCollider.gameObject.CompareTag("Bomb"))
            {
                //EFECTO DE SONIDO DE EXPLOSION
                playerAudioSource.PlayOneShot(explosionClip, 1);

                //COMUNICAMOS QUE HEMOS MUERTO (GAMEOVER)
                gameOver = true;

                isOnGround = false;
            }
        }
    }

}
