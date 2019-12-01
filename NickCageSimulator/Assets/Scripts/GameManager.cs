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

    void Awake()
    {
        GM = this;
        SM = new SceneManager();
        sceneCount = 0;
        endSceneText = null;
        endSceneString = "default text";

    //    SceneManager.LoadScene(sceneBuildIndex:0);
        DontDestroyOnLoad(GM);
        DontDestroyOnLoad(endSceneText);
    }

    // Update is called once per frame
    void Update()
    {

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
}
