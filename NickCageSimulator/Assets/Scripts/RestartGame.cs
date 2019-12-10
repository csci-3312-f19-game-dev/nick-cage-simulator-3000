using UnityEngine;

//The purpose of this class is to restart the game from either ending scene

public class RestartGame : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void restartOnButtonPress()
    {
        GameManager.GM.RestartGame();
    }
}
