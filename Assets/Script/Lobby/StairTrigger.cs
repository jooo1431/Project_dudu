using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairTrigger : MonoBehaviour {

    /*void moveScene()
    {
        SceneManager.LoadScene("RoomSelect_1");
    }*/

    void playSound() //계단 올라가는 소리
    {
        var sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sound.PlaySingle(sound.stairs);
    }

    private void OnTriggerEnter(Collider other)
    {
        playSound();
        //Invoke("moveScene", 3f); //3초 후에 씬이동
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
