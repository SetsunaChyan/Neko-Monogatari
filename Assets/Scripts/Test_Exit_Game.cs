using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Exit_Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width / 2f, Screen.height / 2f, 100, 200), "exit"))
        {
            Application.Quit();
        }
    }
}
