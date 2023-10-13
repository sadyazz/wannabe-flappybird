using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMoveSCript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deathZone = -45;


    
    public float maxMoveSpeed = 50;
    public float speedIncreaseInterval = 10; // Increase speed every 10 pipes
    private float currentMoveSpeed;

    private int pipeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * currentMoveSpeed) * Time.deltaTime;

        if (transform.position.x < deathZone)
        {
            Destroy(gameObject);
        }
    }

    public void PipePassed()
    {
        pipeCount++;

        if (pipeCount % speedIncreaseInterval == 0 && currentMoveSpeed < maxMoveSpeed)
        {
            currentMoveSpeed += 10;
        }
    }
}
