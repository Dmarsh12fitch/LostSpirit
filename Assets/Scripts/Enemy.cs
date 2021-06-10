using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyRigidbody;
    public float enemySpeed = 5;
    public float enemyWillPower = 2;


    public float enemyAttackDamage = 5;
    public float enemyHealth = 10;
    public float enemyArmor = 12;

    public bool canGrabObjects;
    public GameObject grabbedObject;


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
        //check for player within range
        //move enemy closer to enemy or not
        //charge up and then attack player when within range
    }


    public void grabObject(GameObject ob)
    {
        grabbedObject = ob;
        grabbedObject.transform.parent = transform;
    }

     public void dropObject()
    {
        grabbedObject.transform.parent = null;
    }

}
