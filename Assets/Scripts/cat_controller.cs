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
	public int currentTri=5;
	public int currentHeart=5;
	GameObject new_source;
	//	新建的音源

	void Start()
	{
		GameObject maincamera=GameObject.FindGameObjectWithTag("MainCamera2");
		GridHeight=maincamera.GetComponent<main_scene_controller>().GridHeight;
		rigidbody2d=GetComponent<Rigidbody2D>();
		//currentTri=currentHeart=0;
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
				TileBase tb1=tilemap.GetTile(cellPosition1);
				if(tb1==null) flag=false;
				if(flag&&Physics2D.Raycast(rigidbody2d.position+2*vec_detect,vec_detect,0,1<<LayerMask.NameToLayer("Collider")))
					flag=false;
				if(flag)
				{
					Debug.Log(tb1.name);
					if(tb1.name=="tile_boxA")
						if(currentHeart>0) currentHeart--; else flag=false;
					if(tb1.name=="tile_boxB")
						if(currentTri>0) currentTri--; else flag=false;
				}
				if(flag)
				{
					GameObject tmp = (GameObject)Resources.Load("prefab/Box_Source");
					new_source = Instantiate(tmp);	//	实例化
					// Source_Controller sc = tmp.GetComponent<Source_Controller>();
					Debug.Log("TRIANGLE:"+currentTri+"   HEART:"+currentHeart);
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
