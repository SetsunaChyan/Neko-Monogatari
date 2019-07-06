using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_scene_controller : MonoBehaviour 
{
	public float GridHeight;
	private GameObject cat;

	void Start() 
	{
		//设置分辨率
		Screen.SetResolution(1600,900,true);
		
		//初始化猫的位置
		cat=GameObject.FindGameObjectWithTag("Cat");
		cat.GetComponent<Rigidbody2D>().MovePosition(new Vector2(GridHeight/2f,GridHeight/2f));
	}

	void Update()
	{
		Vector3 pos=transform.position;
		pos.x=cat.transform.position.x;
		pos.y=cat.transform.position.y;
		transform.position=pos;
	}
}
