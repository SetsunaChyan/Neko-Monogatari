using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_scene_controller : MonoBehaviour 
{
	public float GridHeight;

	void Start() 
	{
		//设置分辨率
		Screen.SetResolution(1600,900,true);
		
		//初始化猫的位置
		GameObject Cat=GameObject.FindGameObjectWithTag("Cat");
		Cat.GetComponent<Rigidbody2D>().MovePosition(new Vector2(GridHeight/2f,GridHeight/2f));
	}

	void Update()
	{
		
	}
}
