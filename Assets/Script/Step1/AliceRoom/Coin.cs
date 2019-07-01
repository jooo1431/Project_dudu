using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class Coin : MonoBehaviour {

    SoundManager sound;
    bool trigger = false;
    UserData user;

    Leap.Hand userHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Hand"))
        {
            sound.PlaySingle(sound.coinGrab);
            trigger = true;


        }
    }
    // Use this for initialization
    void Start ()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        user = GameObject.Find("UserData").GetComponent<UserData>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        userHand = user.MainHand;

        if (trigger)
        {
           
            if (userHand.GetFistStrength() > 0.65f)
            {
                transform.parent = GameObject.FindGameObjectWithTag("Hand").transform; //코인을 indexfinger에 붙인다
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.Euler(90f, 90f, 180f);
                //trigger = false;
            }
        }

		
	}
}
