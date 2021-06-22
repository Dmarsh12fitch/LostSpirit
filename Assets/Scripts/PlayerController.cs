using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject spirit;
    public Spirit spiritScript;
    public GameObject possessedEnemy;
    public Enemy possessedEnemyScript;

    private Rigidbody playerRigidbody;
    private float playerSpeed;
    private bool spiritForm;


    private float horizontalInput;
    private float verticalInput;

    private Vector2 moveDirection;
    Vector3 tempLoco;


    public enum direction
    {
        Up,
        Right,
        Down,
        Left
    }

    private direction facingDirection;
    public bool isDashing;
    private Vector3 dashVelocity;

    // Start is called before the first frame update
    void Start()
    {
        spiritScript = spirit.GetComponent<Spirit>();
        playerRigidbody = spiritScript.spiritRigidbody;
        playerSpeed = spiritScript.spiritSpeed;
        spiritForm = true;
        facingDirection = direction.Up;
    }

    private void FixedUpdate()
    {
        //get velocity
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //set velocity
        //playerRigidbody.velocity = new Vector3((horizontalInput * playerSpeed), playerRigidbody.velocity.y, (verticalInput * playerSpeed));  //fix the going diagonally makes it go faster problem
        AssignInputs();
        Move();
        takeActions();
        //Animate


        //do more formal thingie
        /*
        if (!spiritForm && Input.GetKeyDown(KeyCode.Space))
        {
            turnBackIntoSpirit();
        }
        */




    }

    void AssignInputs()
    {
        //movement inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        //movement assigned
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        //facingDirection assigned
        if (horizontalInput > 0)
        {
            facingDirection = direction.Right;
        }
        else if (horizontalInput < 0)
        {
            facingDirection = direction.Left;
        }
        if (verticalInput > 0)
        {
            facingDirection = direction.Up;
        }
        else if (verticalInput < 0)
        {
            facingDirection = direction.Down;
        }

        //location stored
        if (possessedEnemy != null)
        {
            tempLoco = new Vector3(possessedEnemy.transform.localPosition.x, 1.0f, possessedEnemy.transform.localPosition.z);
        }
    }

    void Move()
    {
        if (!isDashing)
        {
            playerRigidbody.velocity = new Vector3(moveDirection.x * playerSpeed, 0.0f, moveDirection.y * playerSpeed);
        }
    }

    void takeActions()
    {
        if (spiritForm)
        {
            //dash
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dash();
            }
        } else
        {
            if (possessedEnemyScript.canGrabObjects && Input.GetKeyDown(KeyCode.F))     //AND is touching an object right now
            {
                //possessedEnemyScript.grabObject(GRABABLE OBJECT HERE THAT HAS A TAG AND IS BEING CURRENTLY TOUCHED BY PLAYER);
            }

        }
    }


    public void turnBackIntoSpirit()
    {
        spiritForm = true;
        spirit.SetActive(true);
        spirit.transform.parent = transform;
        spirit.transform.localPosition = tempLoco;
        playerSpeed = spiritScript.spiritSpeed;
        playerRigidbody = spiritScript.spiritRigidbody;
        possessedEnemyScript.killThisEnemy();
        possessedEnemy = null;
    }

    public void PossessThisEnemy(GameObject enemy)
    {
        spirit.SetActive(false);
        spiritForm = false;
        possessedEnemy = enemy;
        possessedEnemy.transform.parent = transform;
        playerSpeed = possessedEnemyScript.enemySpeed;
        playerRigidbody = possessedEnemyScript.enemyRigidbody;
    }






    // Update is called once per frame
    void Update()
    {
        




    }


    void dash()
    {
        if (facingDirection.Equals(direction.Up))
        {
            dashVelocity = new Vector3(0, 0, 100);
        } else if (facingDirection.Equals(direction.Down))
        {
            dashVelocity = new Vector3(0, 0, -100);
        } else if (facingDirection.Equals(direction.Left))
        {
            dashVelocity = new Vector3(-100, 0, 0);
        } else //then Right
        {
            dashVelocity = new Vector3(100, 0, 0);
        }
        playerRigidbody.AddForce(dashVelocity, ForceMode.Impulse);
        isDashing = true;
        StartCoroutine(dashCountdown());
    }

    IEnumerator dashCountdown()
    {
        yield return new WaitForSeconds(1);     //better tme than this
        isDashing = false;
    }

}
