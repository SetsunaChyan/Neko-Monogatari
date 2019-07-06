using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_controller : MonoBehaviour
{
	void Start()
    {
		
	}
	
	void Update()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Cat");
        Vector3 pos = transform.position;
        pos.x = obj.transform.position.x;
        pos.y = obj.transform.position.y;
        transform.position = pos;
	}
}
