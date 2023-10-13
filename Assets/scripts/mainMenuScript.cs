using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mainMenuScript : MonoBehaviour
{
    public logicScript logic;

    public GameObject mainMenuScreen;
    public GameObject game;
    
    public birdScript bird;

    public void Start()
    {
        bird = GameObject.FindObjectOfType<birdScript>();
        mainMenuScreen = GameObject.Find("StartScreen"); 
        game = GameObject.Find("Game");
    }

    public void playGame()
    {
        mainMenuScreen.SetActive(false);
        logic.startGame();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the current active scene is not the start scene (index 0)
        //if (SceneManager.GetActiveScene().buildIndex != 0)
        //{
        //    // Load the start scene (index 0)
        //    SceneManager.LoadScene(0);
        //}
    }
}
