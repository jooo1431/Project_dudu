using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroControl : MonoBehaviour {
    SoundManager sound;
	// Use this for initialization
	void Start ()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sound.PlaySingle(sound.IntroBgm,true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
