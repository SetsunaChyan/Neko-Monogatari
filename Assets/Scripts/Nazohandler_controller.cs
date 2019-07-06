using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Nazohandler_controller : MonoBehaviour 
{
	public Tilemap tilemap;
	public TileBase brick;
	public TileBase floor;

	void Start() 
	{
		
	}

	void Update() 
	{
		
	}

	void setT(float x,float y,TileBase tb)
	{
		Vector2 pos=new Vector2(x,y);
		Vector3Int cpos=tilemap.WorldToCell(pos);
		tilemap.SetTile(cpos,tb);
	}

	public void closeDoor(int num)
	{
		if(num==1)
		{
			setT(-4.5f,6.5f,brick);
			setT(-5.5f,4.5f,brick);
		}
		if(num==2)
		{
			setT(2.5f,6.5f,brick);
			setT(6.5f,7.5f,brick);
		}
		if(num==3)
		{
			setT(6.5f,7.5f,brick);
		}
	}

	public void openDoor(int num)
	{
		if(num==1)
		{
			setT(-4.5f,6.5f,floor);
			setT(-5.5f,4.5f,floor);
		}
		if(num==2)
		{
			setT(2.5f,6.5f,floor);
			setT(6.5f,7.5f,floor);
		}
		if(num==3)
		{
			setT(6.5f,7.5f,floor);
		}
	}
}
