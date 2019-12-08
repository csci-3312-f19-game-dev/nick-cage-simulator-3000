using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public static SceneManager SM;
    int sceneCount;
    public Text endSceneText;
    public string endSceneString; //necessary because text cannot be referenced before screen holding text is loaded.
    bool gameOver = false;

    void Awake()
    {
        GM = this;
        SM = new SceneManager();
        sceneCount = 0;
        endSceneText = null;
        endSceneString = "default text";        

    //    SceneManager.LoadScene(sceneBuildIndex:0);
        DontDestroyOnLoad(GM);
        //DontDestroyOnLoad(endSceneText);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        int unitCount = 0;
        foreach (GameObject tile in tiles)
        {
            unitCount += tile.gameObject.GetComponent<TileHandler>().numUnits();
        }
        if (unitCount == 0 && !gameOver)
        {
            gameOver = true;
            Debug.Log("Game over");
            //GameManager.GM.endSceneText.text = "GAME OVER.";
            endSceneString = "GAME OVER";
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        sceneCount++;

        SceneManager.LoadScene(sceneBuildIndex: sceneCount);

        if (sceneCount == 1) //TODO CHANGE WHEN MULTIPLE SCREENS ARE ADDED
        {
            //ERRORED OUT endSceneText = GameObject.FindGameObjectWithTag("endText").GetComponent<Text>();
            if (endSceneText != null)
            {
                endSceneText.text = endSceneString;
            }
        }
    }

    public void RestartGame()
    {
        sceneCount = 0;
        SceneManager.LoadScene(sceneBuildIndex: sceneCount);
    }
}
