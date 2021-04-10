using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject title;

    public Animator animator; //calls for aniamtor of the object

    public float stopTime;


    // Start is called before the first frame update
    IEnumerator Start()
    {
       // gameObject.GetComponent<Animator>().enabled = true;
        animator.SetBool("boolAnimation", true);        //plays animation and waits -- sec. then stops.

        yield return new WaitForSeconds(stopTime);

        this.GetComponent<Animator>().enabled = false;
        //Stop();
    }


    // Update is called once per frame
    void Update()           //loads secene if A pressed
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene() 
    {
        SceneManager.LoadScene(1); //loads next scene
    }

   
}
