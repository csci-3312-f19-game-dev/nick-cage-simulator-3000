using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionSceenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ScreenOne;
    public GameObject ScreenTwo;
    public GameObject ScreenThree;
    public GameObject ScreenFour;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject playButton;
    private GameObject[] screens;
    private int currentScreen;
    void Start()
    {
        screens = new GameObject[] { ScreenOne, ScreenTwo, ScreenThree, ScreenFour };
        currentScreen = 0;
        updateButtons();
        nextButton.SetActive(true);   
        changeDisplayScreen();
    }

    public void Next()
    {
        currentScreen++;
        updateButtons();
        changeDisplayScreen();
    }
    public void Prev()
    {
        currentScreen--;
        updateButtons();
        changeDisplayScreen();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    private void updateButtons()
    {
        nextButton.SetActive(true);
        if (currentScreen == 0)
        {
            //we are on the first screen so there is no previous
            prevButton.SetActive(false);
        }
        else
        {
            prevButton.SetActive(true);
        }

        if (currentScreen == (screens.Length - 1))
        {
            //on the last screen 
            playButton.SetActive(true);
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
            playButton.SetActive(false);
        }
    }

    private void changeDisplayScreen()
    {
        foreach (var screen in screens)
        {
            screen.SetActive(false);
        }
        screens[currentScreen].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
