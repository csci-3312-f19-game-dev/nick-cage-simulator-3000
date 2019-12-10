using UnityEngine;
using UnityEngine.SceneManagement;

//The purpose of this class is to display the start scene.
public class StartScreenManager : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    public void Instructions(){
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }
}
