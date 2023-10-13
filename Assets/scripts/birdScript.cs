using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logicScript logic;
 
    public bool birdIsAlive = true;
    private bool gameStarted;

    private SpriteRenderer spriteRenderer;
    private bool isFlipped = false;

    //private bool gameStarted = false;

    //private SpriteRenderer spriteRenderer;
    //public Sprite[] sprites;
    //private int spriteIndex;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private mainMenuScript scriptReference;
    
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space)==true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            //flip();
            //
            //float directionMultiplier = isFlipped ? -1f : 1f;
            //myRigidbody.velocity = Vector2.up * flapStrength * directionMultiplier;
            
        }
    }

    private void flip()
    {
        //spriteRenderer.flipY = !spriteRenderer.flipY;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        isFlipped = !isFlipped;
    }

    public void DoSomethingAfterEvery30Points()
    {
        if (logic.playerScore >= 5 && !isFlipped)
        {
            Debug.Log("Flipping the bird!");
            flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    public void StartGame()
    {
        gameStarted = true; 
        birdIsAlive = true; 
    }
}
