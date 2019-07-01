using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip elevOpen;
    public AudioClip stairs;
    public AudioClip LightOn;
    public AudioClip btnClick;
    public AudioClip coinGrab;
    public AudioClip IntroBgm;
    

    AudioSource audioSource;

    public void PlaySingle(AudioClip clip, bool loop = false)
    {
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }
    // Use this for initialization
    void Awake ()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
