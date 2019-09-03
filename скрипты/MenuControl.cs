using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public void PlayPressed()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }



    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}