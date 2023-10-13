using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 3;
    private float timer = 0;
    public float heightOffSet = 10;
    public GameObject cloud;

    private bool gameStarted = false;
    public logicScript logic;
    

    void Start()
    {
       //InvokeRepeating(nameof(spawnPipe), spawnRate, spawnRate);
       //InvokeRepeating(nameof(spawnClouds), spawnRate, spawnRate);
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(spawnPipe), spawnRate, spawnRate);
        InvokeRepeating(nameof(spawnClouds), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(spawnPipe));
        CancelInvoke(nameof(spawnClouds));
    }

    private void spawnClouds()
    {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;

        float randomY = Random.Range(lowestPoint, highestPoint);
        while (randomY > lowestPoint)
        {
            Instantiate(cloud, new Vector3(transform.position.x, randomY, 0), transform.rotation);
            randomY -= heightOffSet;
        }

    }
    //void Update()
    //{
    //    if (gameStarted)
    //    {
    //        if (timer < spawnRate)
    //        {
    //            timer += Time.deltaTime;
    //        }
    //        else
    //        {
    //            timer = 0;
    //            spawnPipe();
    //            spawnClouds();
    //        }
    //    }
    //}

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;
        
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

    }
}
