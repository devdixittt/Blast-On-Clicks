using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody Targetrb;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private GameManager gameManager;
    private float Torquespeed = 10.0f;
    private float xRange = 6.0f;
    public ParticleSystem explosionVFX;

    public int points;
    // Start is called before the first frame update
    void Start()
    {
        Targetrb = GetComponent<Rigidbody>();
        Targetrb.AddForce(RandomForce(), ForceMode.Impulse);
        Targetrb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionVFX, transform.position, explosionVFX.transform.rotation);
            gameManager.UpdateScore(points);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("bad") && gameManager.isGameActive )
        {
            gameManager.Live(-1);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-Torquespeed, Torquespeed);
    }
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -3);
    }
}
