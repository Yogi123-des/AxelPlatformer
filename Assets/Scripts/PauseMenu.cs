using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("level 1");
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
