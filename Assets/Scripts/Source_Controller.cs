using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source_Controller : MonoBehaviour
{
	public AudioSource source;
	//	音源
	public AudioClip SE;
	//	音效
	public float TTL = 5f;
	//	一段时间后结束

	void Start ()
	{
		source = GetComponent<AudioSource>();
		source.PlayOneShot(SE);
	}
	public void PlaySound(AudioClip clip)
	{
		source.PlayOneShot(clip);
	}
	
	void Update ()
	{
		TTL -= Time.deltaTime;
		if(TTL < 0f)
			Destroy(gameObject);
	}
}
