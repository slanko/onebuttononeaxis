using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
   
    public void quitGame()
    {
        Application.Quit();
    }

    public void loadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
