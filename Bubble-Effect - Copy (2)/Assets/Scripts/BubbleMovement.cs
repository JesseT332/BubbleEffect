using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject bubble;
    public GameObject lives;
    public GameObject gameOver, pauseButton, scoreText, victory;

    public Rigidbody2D rb;

    public float playerSpeed = 5f;

    public float oldPositionX;
    public float newPositionX;
    public float oldPositionY;
    public float newPositionY;
    //  public float waitTime;

    private Vector2 moveDirection;

  //  public Animator animator;
    public Animator imageAnimator;
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

       
        newPositionX = transform.position.x;
        newPositionY = transform.position.y;

        if (Input.GetKeyDown(KeyCode.Space)) //Player turns into a bubble
        {

            bubble.SetActive(true);
            player.SetActive(false);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10.5f, 10.5f), Mathf.Clamp(transform.position.y, -4f, 5), transform.position.z);
    }

    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("HEHEHE");

            Destroy(other.gameObject);

            lifeDecrease -= 1;

            imageAnimator.SetInteger("intLife", lifeDecrease);

            if (lifeDecrease <= 0)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);

            points += 1;

            if (points == 3)
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
}
