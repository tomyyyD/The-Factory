using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void AboutButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtont()
    {
        Application.Quit();
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
