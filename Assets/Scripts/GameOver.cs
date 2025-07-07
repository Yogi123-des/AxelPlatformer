using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadSceneAsync("level 1");
    }

    public void BackToMenu1()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
