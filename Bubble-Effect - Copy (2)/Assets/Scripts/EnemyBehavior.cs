using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public float lookAtRadius = 5f;
    public float speed;

    public float deathTime;

    public float oldPositionX; //enemies tracker fro it's position
    public float newPositionX;
    public float oldPositionY;
    public float newPositionY;

    public Animator animator;

    private Transform player;
    private Transform bubble;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //bubble = GameObject.FindGameObjectWithTag("Bubble").transform;

        StartCoroutine("DeathCount");
    }

    // Update is called once per frame
    void Update() //enemy movement
    {
        oldPositionX = transform.position.x;
        oldPositionY = transform.position.y;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        //float distanceFromBubble = Vector2.Distance(bubble.position, transform.position);


        if (distanceFromPlayer < lookAtRadius)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime); // lest the enemy move around
            
        }

        /*if (distanceFromBubble < lookAtRadius)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, bubble.position, speed * Time.deltaTime);

        }*/

        newPositionX = transform.position.x;
        newPositionY = transform.position.y;

        if (newPositionX > oldPositionX) //plays animation for going RIGHT
        {
           // Debug.Log("moved right");
            animator.SetBool("boolRight", true);
            animator.SetBool("boolLeft", false);
            animator.SetBool("boolIdle", false);
            animator.SetBool("boolBack", false);
        }

        if (newPositionX < oldPositionX) //plays animations for going LEFT
        {
            //Debug.Log("moved left");
            animator.SetBool("boolLeft", true);
            animator.SetBool("boolRight", false);
            animator.SetBool("boolIdle", false);
            animator.SetBool("boolBack", false);

        }

        if (newPositionX == oldPositionX) //Idle satys still
        {
            animator.SetBool("boolBack", false);
            animator.SetBool("boolLeft", false);
            animator.SetBool("boolRight", false);
            animator.SetBool("boolIdle", true);
        }

        if (newPositionY > oldPositionY) //plays aniamtion for going UP
        {
           // Debug.Log("Moved down");
            animator.SetBool("boolBack", true);
            animator.SetBool("boolLeft", false);
            animator.SetBool("boolRight", false);
            animator.SetBool("boolIdle", false);

        }

        if (newPositionY < oldPositionY) //plays animation for going Down
        {
           // Debug.Log("Moved up");
            animator.SetBool("boolBack", false);
            animator.SetBool("boolLeft", false);
            animator.SetBool("boolRight", false);
            animator.SetBool("boolIdle", true);
        }
    }

    IEnumerator DeathCount ()
    {
        yield return new WaitForSeconds(deathTime); //waits for -- sec. to destroy itself.
        Destroy(gameObject);
    }

        void OnDrawGizmosSelected() //draw radius fro enemy's line of vision
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookAtRadius);
        }

}
