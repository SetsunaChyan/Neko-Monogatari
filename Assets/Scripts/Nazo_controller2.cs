using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nazo_controller2 : MonoBehaviour 
{
	public int NazoNum;
	private int flag;

	void Start () 
	{
		flag=0;
	}
	
	void Update () 
	{
		
	}

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(flag==1) return;
		flag=1;
		GameObject.FindGameObjectWithTag("NazoHandler").GetComponent<Nazohandler_controller>().openDoor(NazoNum);
	}
}
