using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void MainMenuButton ()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPlayButton ()
    {
        SceneManager.LoadScene(2);
    }
}