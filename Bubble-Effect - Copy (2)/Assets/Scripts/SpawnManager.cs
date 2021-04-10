using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject coin;

    public GameObject[] arraySpawnPoint;

    public int indexNumber;
    public int coinCount;

    public float time = 2f;
    public float repeatTime = 3f;


    public float minX;      //spawn boundries
    public float maxX;

    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", time, repeatTime); //repeats the spawn method
    }

    // Update is called once per frame
    void Update()
    {
        coinCount = GameObject.FindGameObjectsWithTag("Coin").Length; //if the game does not see any coins it will spawn another
        if(coinCount == 0)
        {
            SpawnCoins();
        }
     
    }

    void SpawnEnemy()
    {
      Instantiate(enemy, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), enemy.transform.rotation); //instaniats/spawns enemies randomly
    }

    public void SpawnCoins()
    {
        indexNumber = Random.Range(0, arraySpawnPoint.Length); //will randomize the spawn of coins

        for (int i = 0; i < 1; i++)
        {
            Instantiate(coin, arraySpawnPoint[indexNumber].transform.position, transform.rotation);

        }
    }
}
