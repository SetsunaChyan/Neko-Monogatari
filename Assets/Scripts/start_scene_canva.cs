using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start_scene_canva : MonoBehaviour {

    public Canvas canvas;
    public Button start_button, exit_button;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void start_game()
    {
        SceneManager.LoadScene("hint_scene");
    }

    public void exit_game()
    {
        Application.Quit();
    }
}
