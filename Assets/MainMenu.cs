using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{

    public string scene = "Level 1";

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
