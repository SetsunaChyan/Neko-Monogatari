using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onTriggerEnter2D(Collider2D other)
    {
        Debug.Log("QQQAAA");
    }
}
