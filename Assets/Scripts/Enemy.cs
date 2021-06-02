using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyRigidbody;
    public float enemySpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    public void killThisEnemy()
    {
        //trigger kill animation
        Destroy(gameObject);
    }







    // Update is called once per frame
    void Update()
    {
        
    }
}
