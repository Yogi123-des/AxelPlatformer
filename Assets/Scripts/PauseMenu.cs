using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public void Pause()
    {
        Time.timescale = 0;
    }
    public void Playon()
    {
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("level 1");
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}
