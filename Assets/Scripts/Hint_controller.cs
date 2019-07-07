using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_controller : MonoBehaviour
{
    public float timerMax;
    private float timer;
    private int flag;
    private GameObject tmp;

    void Start()
    {
        flag = 0;
	}

	void Update()
    {
		if(flag==1&&timer>0)
        {
            Vector3 pos = GameObject.FindGameObjectWithTag("Cat").transform.position;
            pos.x -= 4.3f; pos.y += 3;
            tmp.transform.position = pos;
            timer -= Time.deltaTime;
        }
        else if(flag==1&&timer<=0)
        {
            Debug.Log("qqqqqqqqqqqqqqqqqqqq");
            flag = 2;
            GameObject.Destroy(tmp);
        }

	}
    public void display()
    {
        Debug.Log("qaqqqqqq");
        if (flag == 1 || flag==2) return;
        tmp = (GameObject)Resources.Load("prefab/HUD_hint");
        Vector3 pos=GameObject.FindGameObjectWithTag("Cat").transform.position;
        pos.x -=4.3f;pos.y +=3;
        tmp.transform.position = pos;
        tmp=Instantiate(tmp);	//	实例化
        timer = timerMax;
        flag = 1;
    }
}
