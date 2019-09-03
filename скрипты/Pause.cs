using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    private bool paused = false;
    [SerializeField] private Text pause;
    private bool guipuse = false;

    void Start ()
    {
        pause.text = "";
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                pause.text = "PAUSE";
                guipuse = true;
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                pause.text = "";
                guipuse = false;
            }
        }
    }
    public void OnGUI()
    {
        if (guipuse == true)
        {
            Cursor.visible = true;
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 150f, 45f), "Продолжить"))
            {
                paused = false;
                pause.text = "";
                guipuse = false;
                Time.timeScale = 1;
            }

            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 150f, 45f), "В Меню"))
            {
                paused = false;
                SceneManager.LoadScene ("Menu");

            }
        }
    }
}
