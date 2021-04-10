using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingAni : MonoBehaviour
{
    public GameObject load;
    public GameObject next1;
    public GameObject next2;
    public GameObject story;
    public GameObject controls;        //Project gameobjects

    public Animator animator;
    public Animator storyAnimator;

    public float stopTime;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        story.SetActive(false);
        controls.SetActive(false); //disables objects
        next1.SetActive(false);
        next2.SetActive(false);
        load.SetActive(true);

        animator.SetBool("boolLoad", true);         //start animation adn wait -- sec.

        yield return new WaitForSeconds(stopTime); 

        this.GetComponent<Animator>().enabled = false;

        Active();        //callas method

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //the methid below turn on and off gameobjects
    
    public void Active()
    {  
        controls.SetActive(true); //sets the enables the object from the project
        next1.SetActive(true);
        load.SetActive(true);
    }

    public void NextPage()
    {
        controls.SetActive(false);
        next1.SetActive(false);
        load.SetActive(true);
        story.SetActive(true);
        storyAnimator.SetBool("boolStory", true);
        next2.SetActive(true);

    }
    public void LoadNext()
    {
        SceneManager.LoadScene(2); //button loads next scene
    }

   
}
