using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip hitHurt, pickUpCoin, powerUp;

    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        hitHurt = Resources.Load<AudioClip>("hitHurt");
        pickUpCoin = Resources.Load<AudioClip>("pickUpCoin");
        powerUp = Resources.Load<AudioClip>("powerUp");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SoundPLayer(string clip)
    {
        switch(clip)
        {
            case "hitHurt":
                audioSource.PlayOneShot(hitHurt);
                break;
            case "pickUpCoin":
                audioSource.PlayOneShot(pickUpCoin);
                break;
        }
    }
}
