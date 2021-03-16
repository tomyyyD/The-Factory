using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EndScene
{

    public static int currScene = SceneManager.GetActiveScene().buildIndex;

    public static void NextScene()
    {
        SceneManager.LoadScene(currScene + 1);
        currScene++;
    }

    public static void NextSceneAdd()
    {
        SceneManager.LoadScene(currScene + 1, LoadSceneMode.Additive);
        currScene++;
    }
    public static void ResetScene()
    {
        SceneManager.LoadScene(currScene);
        Debug.Log("resetting");
    }
    public static void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void activate(GameObject stuff)
    {
        stuff.SetActive(true);
    }
}
