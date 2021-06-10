using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public Rigidbody spiritRigidbody;
    public float spiritSpeed = 5;
    public float spiritWillPower = 11;

    public float spiritAttackDamage = 5;
    public float spiritHealth = 50;

    //other things

    
    // Start is called before the first frame update
    void Start()
    {
        spiritRigidbody = GetComponent<Rigidbody>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && playerControllerScript.isDashing)
        {
            if(collision.gameObject.GetComponent<Enemy>().enemyWillPower <= 0)
            {
                playerControllerScript.PossessThisEnemy(collision.gameObject);
            } else
            {
                collision.gameObject.GetComponent<Enemy>().enemyWillPower -= 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
