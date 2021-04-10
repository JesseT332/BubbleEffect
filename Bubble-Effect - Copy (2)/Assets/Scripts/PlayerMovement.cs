using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public GameObject player;
  //  public GameObject bubble;      //project's gameObjects
    public GameObject lives;
    public GameObject gameOver, pauseButton, scoreText, victory;

    public Rigidbody2D rb; //players phyics

    public float playerSpeed = 5f;

    public float oldPositionX; //tracks the player position
    public float newPositionX;
    public float oldPositionY;
    public float newPositionY;

    public float count;
  //  public float waitTime;

    private Vector2 moveDirection;

    public Animator animator;
    public Animator imageAnimator; //calls the animators from the project 
    public Animator victoryAimator;

    public int lifeDecrease = 3;
    public int points = 0;

  //  public IEnumerator Coroutine;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        //Coroutine = WaitAndDo(waitTime);
      //  StartCoroutine(Coroutine);
        imageAnimator.SetInteger("intLife", lifeDecrease);
    }

    // Update is called once per frame
    void Update()
    {
        oldPositionX = transform.position.x;
       oldPositionY = transform.position.y;

        //Player movement code 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(movement.x, movement.y).normalized;

        if (newPositionX < oldPositionX) //animation for going RIGHT        
        { 
          //  Debug.Log("right");
            animator.SetInteger("DirectionINT", 2);
           
        }

        if (newPositionX > oldPositionX) //aniamtion for going LEFT
        {
          //  Debug.Log("left");
            animator.SetInteger("DirectionINT", 1);
       
        }

        if (movement.x == 0 && movement.y ==0) //aniamtion for Idle
        {
            animator.SetInteger("DirectionINT", 0);
        }

        if(newPositionY > oldPositionY) //aniamtion for going UP
        {
            animator.SetInteger("DirectionINT", 3);
        }

        if(newPositionY < oldPositionY) //animation for going DOWN
        {
            animator.SetInteger("DirectionINT", 4);
        }

        newPositionX = transform.position.x;
        newPositionY = transform.position.y;

       /* if(Input.GetKeyDown(KeyCode.Space)) //Player turns into a bubble
        {
          
            bubble.SetActive(true);
            player.SetActive(false);
        }*/

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10.5f, 10.5f), Mathf.Clamp(transform.position.y, -4f, 5), transform.position.z); //prevents the player from leaving the cameras view
    }

    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed); //adjusts the player speed
    }

     void OnTriggerEnter2D(Collider2D other) //if the enemy touvhes the player it will deduct a life and be destroyed
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("HEHEHE");

            SoundManager.SoundPLayer("hitHurt");

            Destroy(other.gameObject);

            lifeDecrease -= 1;

            imageAnimator.SetInteger("intLife", lifeDecrease);

            if(lifeDecrease <= 0)
            {
                Debug.Log("GAMEOVER");

                // WaitAndDo();
               
                Time.timeScale = 0f;

                victory.SetActive(false);
                gameOver.SetActive(true);
                scoreText.SetActive(false);
                pauseButton.SetActive(false);
                lives.SetActive(false);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //if player touches coin it will be destroyed and added to points
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);

            SoundManager.SoundPLayer("pickUpCoin");

            points += 1;

            if(points == count)
            {
                Time.timeScale = 0f;

                gameOver.SetActive(false);
                scoreText.SetActive(false);
                pauseButton.SetActive(false);
                lives.SetActive(false);
                victory.SetActive(true);
                victoryAimator.SetBool("boolVictory", true);
            }
        }
    }

   /* IEnumerator WaitAndDo()
    {
        yield return new WaitForSeconds(waitTime);
    }*/
}
