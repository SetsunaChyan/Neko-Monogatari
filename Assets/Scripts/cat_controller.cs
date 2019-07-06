using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cat_controller : MonoBehaviour 
{
	private const int LEFT=0;
	private const int RIGHT=1;
	private const int UP=2;
	private const int DOWN=3;

	private int direction=LEFT;
	private float GridHeight;

	private Rigidbody2D rigidbody2d;

	public Tilemap tilemap;
	public Tile boxTile;

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
		Vector2 vec_detect=new Vector2(0,0);
		if(keyPressed==LEFT) vec_detect=new Vector2(-1,0);
		else if(keyPressed==RIGHT) vec_detect=new Vector2(1,0);
		else if(keyPressed==UP) vec_detect=new Vector2(0,1);
		else if(keyPressed==DOWN) vec_detect=new Vector2(0,-1);

		if(Physics2D.Raycast(rigidbody2d.position,vec_detect,GridHeight,1<<LayerMask.NameToLayer("Collider"))) 
		{
    		GameObject obj=Physics2D.Raycast(rigidbody2d.position,vec_detect,GridHeight,1<<LayerMask.NameToLayer("Collider")).collider.gameObject;
			if(obj.name=="Box")
			{
				bool flag=true;
				Vector3Int cellPosition1=tilemap.WorldToCell(rigidbody2d.position+vec_detect);
				Vector3Int cellPosition2=tilemap.WorldToCell(rigidbody2d.position+2*vec_detect);
				Vector2 cellPosition1_2d=new Vector2(0,0);
				cellPosition1_2d.x+=cellPosition1.x;cellPosition1_2d.y+=cellPosition1.y;
				if(Physics2D.Raycast(cellPosition1_2d,vec_detect,GridHeight,1<<LayerMask.NameToLayer("Collider")))
				{
					TileBase tb2=tilemap.GetTile(cellPosition2);
					if(tb2!=null) flag=false;
				}
				TileBase tb1=tilemap.GetTile(cellPosition1);
				if(tb1!=null&&flag)
				{
					tilemap.SetTile(cellPosition1,null);
					tilemap.SetTile(cellPosition2,tb1);
					rigidbody2d.MovePosition(rigidbody2d.position+vec_detect);
				} 
			}
		}

		//判断前方是否有障碍物
		if(keyPressed!=-1)
		{
			//如果没有障碍物则移动
			if(!Physics2D.Raycast(rigidbody2d.position,vec_detect,GridHeight,1<<LayerMask.NameToLayer("Collider"))) 
			{
        		Vector2 newpos=rigidbody2d.position+vec_detect;
        		rigidbody2d.MovePosition(newpos);
			}
		}
	}
}
