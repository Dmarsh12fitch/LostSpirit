using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject spirit;
    public GameObject possessedEnemy;

    private Rigidbody playerRigidbody;
    private float playerSpeed;
    private bool spiritForm;


    private float horizontalInput;
    private float verticalInput;

    Vector3 tempLoco;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = spirit.GetComponent<Rigidbody>();
        playerSpeed = spirit.GetComponent<Spirit>().spiritSpeed;
        spiritForm = true;
    }

    private void FixedUpdate()
    {
        //get velocity
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //set velocity
        playerRigidbody.velocity = new Vector3((horizontalInput * playerSpeed), playerRigidbody.velocity.y, (verticalInput * playerSpeed));  //fix the going diagonally makes it go faster problem
        if(possessedEnemy != null)
        {
            //tempLoco = possessedEnemy.transform.localPosition;
            
            tempLoco = new Vector3(possessedEnemy.transform.localPosition.x, 1.0f, possessedEnemy.transform.localPosition.z);
        }

        if (!spiritForm && Input.GetKeyDown(KeyCode.Space))
        {
            turnBackIntoSpirit();
        }





    }


    public void turnBackIntoSpirit()
    {
        


        spiritForm = true;
        spirit.SetActive(true);
        //spirit.transform.position = new Vector3(1, 1, 1);
        //spirit.transform.position = tempLoco;

        spirit.transform.parent = transform;
        //spirit.transform.position = new Vector3(0, 0, 0);
        Debug.Log("TempLoco: " + tempLoco.ToString());
        spirit.transform.localPosition = tempLoco;                 //why wont this work?
        //spirit.transform.localPosition = new Vector3(spirit.transform.localPosition.x, 1, spirit.transform.localPosition.z);

        playerSpeed = spirit.GetComponent<Spirit>().spiritSpeed;
        playerRigidbody = spirit.GetComponent<Spirit>().spiritRigidbody;
        possessedEnemy.GetComponent<Enemy>().killThisEnemy();
        possessedEnemy = null;
        

    }

    public void PossessThisEnemy(GameObject enemy)
    {
        spirit.SetActive(false);
        spiritForm = false;
        possessedEnemy = enemy;
        possessedEnemy.transform.parent = transform;
        playerSpeed = possessedEnemy.GetComponent<Enemy>().enemySpeed;
        playerRigidbody = possessedEnemy.GetComponent<Enemy>().enemyRigidbody;
    }






    // Update is called once per frame
    void Update()
    {
        




    }
}
