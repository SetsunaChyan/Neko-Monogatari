using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_collect : MonoBehaviour 
{
	public int probtype;

	void Start() 
	{
		
	}
	
	void Update() 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		cat_controller cat=other.GetComponent<cat_controller>();
		if(cat==null) return;
		if(probtype==0) cat.currentHeart++;
		else cat.currentTri++;
		Destroy(gameObject);
		GameObject tmp = (GameObject)Resources.Load("prefab/Item_Source");
		Instantiate(tmp);	//	实例化
	}
}
