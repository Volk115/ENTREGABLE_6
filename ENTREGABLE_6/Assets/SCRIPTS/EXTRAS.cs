using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXTRAS : MonoBehaviour
{
    private Vector3 initialPos = Vector3.zero;
    public float speed = 15f;
    private float horizontalInput;
    private float xRange = 20f;

    public GameObject proyectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPos;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Se dispara una pizza
            Instantiate(proyectilePrefab, transform.position, proyectilePrefab.transform.rotation);
        }

    }
}
