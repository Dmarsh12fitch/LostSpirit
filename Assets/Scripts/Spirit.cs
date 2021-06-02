using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public Rigidbody spiritRigidbody;
    public float spiritSpeed = 5;
    //other things


    // Start is called before the first frame update
    void Start()
    {
        spiritRigidbody = GetComponent<Rigidbody>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerControllerScript.PossessThisEnemy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
