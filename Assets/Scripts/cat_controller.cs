using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_controller : MonoBehaviour 
{
	private const int LEFT=0;
	private const int RIGHT=1;
	private const int UP=2;
	private const int DOWN=3;

	private int direction=LEFT;
	private float GridHeight;

	private Rigidbody2D rigidbody2d;

	void Start()
	{
		GameObject maincamera=GameObject.FindGameObjectWithTag("MainCamera");
		GridHeight=maincamera.GetComponent<main_scene_controller>().GridHeight;
		rigidbody2d=GetComponent<Rigidbody2D>();
	}
	
	void Update() 
	{
		Vector2 pos=rigidbody2d.position;

		int keyPressed=-1;
		if(Input.GetKeyDown(KeyCode.LeftArrow)) keyPressed=LEFT;
		else if(Input.GetKeyDown(KeyCode.RightArrow)) keyPressed=RIGHT;
		else if(Input.GetKeyDown(KeyCode.UpArrow)) keyPressed=UP;
		else if(Input.GetKeyDown(KeyCode.DownArrow)) keyPressed=DOWN;

		//更新朝向
		if(keyPressed==LEFT) direction=LEFT;
		else if(keyPressed==RIGHT) direction=RIGHT;
		if(direction==LEFT) transform.localScale=new Vector3(1,1,1);
		else if(direction==RIGHT) transform.localScale=new Vector3(-1,1,1);

		//判断前方是否有互动
		Vector2 vec_detect=new Vector2(-1,0);
		if(keyPressed==RIGHT) vec_detect=new Vector2(1,0);
		else if(keyPressed==UP) vec_detect=new Vector2(0,1);
		else if(keyPressed==DOWN) vec_detect=new Vector2(0,-1);

		//判断前方是否有障碍物
		if(keyPressed!=-1)
		{
			//如果没哟障碍物则移动
			if(!Physics2D.Raycast(rigidbody2d.position,vec_detect,GridHeight,1<<LayerMask.NameToLayer("Collider"))) 
			{
        		Vector2 newpos=rigidbody2d.position+vec_detect;
        		rigidbody2d.MovePosition(newpos);
			}
		}
	}
}
