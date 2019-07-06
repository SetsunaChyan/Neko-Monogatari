using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transfer_Scripts : MonoBehaviour
{

    private static Transfer_Scripts Transfer_Scripts_Instance = null;
    public static Transfer_Scripts Instance
    {
        get
        {
            if (Transfer_Scripts_Instance == null)
            {
                Transfer_Scripts_Instance = new Transfer_Scripts();
            }
            return Transfer_Scripts_Instance;
        }
    }
    private Transfer_Scripts() { }

    public GameObject load_Transfer_Background;
    private RawImage Transfer_Background;

    void Awake()
    {
        if (load_Transfer_Background)
        {
            Transfer_Background = load_Transfer_Background.GetComponent<RawImage>();
        }
    }

    public float speed = 1f;
    private bool is_scene_to_white = true;
    private bool is_scene_to_black = false;
    private void to_black()
    {
        Transfer_Background.color = Color.Lerp(Transfer_Background.color, Color.black, speed * Time.deltaTime);
    }

    private void to_white()
    {
        Transfer_Background.color = Color.Lerp(Transfer_Background.color, Color.clear, speed * Time.deltaTime);
    }

    private void scene_to_white()
    {
        to_white();
        if (Transfer_Background.color.a <= 0.05f)
        {
            Transfer_Background.color = Color.clear;
            Transfer_Background.enabled = false;
            is_scene_to_white = false;
        }
    }

    private void scene_to_black()
    {
        Transfer_Background.enabled = true;
        to_black();
        if (Transfer_Background.color.a >= 0.95f)
        {
            Transfer_Background.color = Color.black;
            is_scene_to_black = false;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (is_scene_to_white)
        {
            scene_to_white();
        }
        else if (is_scene_to_black)
        {
            scene_to_black();
        }
    }
}
