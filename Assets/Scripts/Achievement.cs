using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Achievement : MonoBehaviour
{
    public string str;
    int flag = 1;
    // Use this for initialization
    private static Achievement Achievement_Instance = null;
    //	成就图假装成功与否
    public static Achievement Instance
    {
        get
        {
            if (Achievement_Instance == null)
            {
                Achievement_Instance = new Achievement();
            }
            return Achievement_Instance;
        }
    }
    private Achievement() { }
    private RawImage achv;
    //	成就图
    public GameObject load_achv;
    private RawImage hint;
    //  提示图
    public GameObject load_hint;

    void Awake()
    {
        if (load_achv)
            achv = load_achv.GetComponent<RawImage>();
    }
    public float speed = 0.01f;
    public float sleepingTime = 2f;
    public float TTL = 8f;
    void Start()
    {
        achv = load_achv.GetComponent<RawImage>();
        hint = load_hint.GetComponent<RawImage>();
        Color tmp = achv.color;
        tmp.a = 0.001f;     //	完全透明
        achv.color = tmp;
        tmp = hint.color;
        tmp.a = 0.001f;     //	完全透明
        hint.color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 0) return;
        if (sleepingTime > 0f)
            sleepingTime -= Time.deltaTime;
        else
        {
            if (achv.color.a >= 0.9f)
            {
                Color tmp = achv.color;
                tmp.a = 1f;     //	完全不透明
                achv.color = tmp;
            }
            else
            {
                Color tmp = achv.color;
                tmp.a += speed;
                achv.color = tmp;
            }
            TTL -= Time.deltaTime;
            if(TTL < 0f)
            {
                flag = 0;
                SceneManager.LoadScene("hint_scene_R");
                //SceneManager.UnloadScene(str);
            }
        }
    }
}