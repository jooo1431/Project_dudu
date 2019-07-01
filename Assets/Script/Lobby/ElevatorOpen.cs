using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorOpen : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetTrigger("Open");
        playSound();
    }

    void playSound() //엘베 열리는 소리
    {
        var sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sound.PlaySingle(sound.elevOpen);
    }

    /*void moveScene()
    {
        SceneManager.LoadScene("RoomSelect_1");
    }*/
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
