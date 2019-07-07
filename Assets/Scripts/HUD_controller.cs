using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_controller : MonoBehaviour 
{
	private int[] currentNum=new int[2];
	private cat_controller cat;
	private GameObject[][] obj=new GameObject[20][];
	private string[] src=new string[2];

	void Start() 
	{
		cat=GameObject.FindGameObjectWithTag("Cat").GetComponent<cat_controller>();
		for(int i=0;i<20;i++)
			obj[i]=new GameObject[2];
		src[0]="HeartUI";
		src[1]="TriUI";
	}
	
	void Update() 
	{
		for(int i=0;i<20;i++)
			for(int j=0;j<2;j++)
			{
				if(obj[i][j]==null) continue;
				Vector3 pos=GameObject.FindGameObjectWithTag("Cat").transform.position;
				pos.z=-5;
				pos.x+=0.7f*i-6;pos.y+=-0.7f*j+5;
				obj[i][j].transform.position=pos;
			}
		while(cat.currentHeart>currentNum[0]) add(0);
		while(cat.currentTri>currentNum[1]) add(1);
		while(cat.currentHeart<currentNum[0]) used(0);
		while(cat.currentTri<currentNum[1]) used(1);
	}

	void add(int probytpe)
	{
		obj[currentNum[probytpe]][probytpe]=Instantiate((GameObject)Resources.Load(src[probytpe]));
		currentNum[probytpe]++;
	}

	void used(int probytpe)
	{
		--currentNum[probytpe];
		GameObject.Destroy(obj[currentNum[probytpe]][probytpe]);
	}
}
