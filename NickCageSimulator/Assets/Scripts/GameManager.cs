using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//The purpose of this class is to facilitate the switching of scenes

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
        DontDestroyOnLoad(GM);
    }

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
            endSceneString = "DEFAULT STRING";
            ChangeScene();
        }
    }

    //Change to next scene in order
    public void ChangeScene() //only if player lost
    {
        sceneCount++;
        SceneManager.LoadScene(sceneBuildIndex: sceneCount);
        endSceneString = "GAME OVER";

        if (sceneCount == 1) //TODO CHANGE WHEN MULTIPLE SCREENS ARE ADDED
        {
            if (endSceneText != null)
            {
                endSceneText.text = endSceneString;
            }
        }
    }

    //Change to End/Win scene. Necessary because this skips the End/Lose scene in the sequence
    public void ChangeSceneWin()
    {
        sceneCount += 2;

        SceneManager.LoadScene(sceneBuildIndex: sceneCount);

        endSceneString = "YOU WON";

        if (sceneCount == 2) //TODO CHANGE WHEN MULTIPLE SCREENS ARE ADDED
        {
            if (endSceneText != null)
            {
                endSceneText.text = endSceneString;
            }
        }
    }

    //Restart the game from gameplay scene from either end scene
    public void RestartGame()
    {
        sceneCount = 0;
        SceneManager.LoadScene(sceneBuildIndex: sceneCount);
    }
}
