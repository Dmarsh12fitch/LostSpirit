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
    public float enemyArmor = 12;       //NONE FOR NOW

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
    void FixedUpdate()
    {
        //check for player within range
        //move enemy closer to player if in range. if not randomly move
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
