using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    SpriteRenderer CharRender;
    public int jumpHeight;
    public int jumpCounter;
    public int Gravity = 3;
    public Rigidbody2D rb;
    public Collider2D other;
    public bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        CharRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move left or right
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left  * Time.deltaTime);
            CharRender.flipX = false;
            //LimitMovement();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right  * Time.deltaTime);
            CharRender.flipX = true;
            //LimitMovement();
        }
        // S slam down like supermeat boy dive 
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.down * 25 * Time.deltaTime);
        }
 



        //check on ground Y vel 0 means on ground 
        if (rb.velocity.y >= 0)
        {
            onGround = true;
        }
        else { onGround = false; }

            //jump on space or W
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {

                if(jumpCounter <= 4)
                {
                    //transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    onGround = false;
                    jumpCounter++;
                }
                else
                {
                    transform.Translate(Vector3.zero);
                    onGround = true;
                }
        }
     }
       

  /*  
   *  didnt have the current bounds nessessties other than in Y dir and movement changes 
   *  void LimitMovement()
    {

        if (transform.position.x >= xRange)
        {
            // Sets current position to new position capping movement at +/- zRange
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -xRange)
        {
            // Sets current position to new position capping movement at +/- zRange
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

    }*/
}

