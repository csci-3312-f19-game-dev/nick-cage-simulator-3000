using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public static SceneManager SM;
    int sceneCount;

    void Awake()
    {
        GM = this;
        SM = new SceneManager();
        sceneCount = 0;

        SceneManager.LoadScene(sceneBuildIndex:0);
        DontDestroyOnLoad(GM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        sceneCount++;
        SceneManager.LoadScene(sceneBuildIndex: sceneCount);
    }
}
