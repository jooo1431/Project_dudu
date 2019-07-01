using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class CardKey : MonoBehaviour {

    Leap.Hand userMain;
    UserData user;

    bool handTouched = false;
    bool firstGrab = false;
    bool grabbed = false;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HandEnteredBottle");
        handTouched = true;
    }

    // Use this for initialization
    void Start ()
    {
        user = GameObject.Find("UserData").GetComponent<UserData>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        userMain = user.MainHand;

        if (handTouched)
        {
            if (userMain.GetFistStrength() > 0.65f && !firstGrab) //처음에만 일로 들어옴
            {
                firstGrab = true;
                grabbed = true;
                Debug.Log("Firstgrabbed");
            }

            while (grabbed)//한번 들어갓다가 바로 나감
            {
                Debug.Log("grabbed");
                transform.parent = GameObject.FindGameObjectWithTag("rightPalm").transform;
                transform.localPosition = new Vector3(0, -0.02f, -0.11f);
                transform.localRotation = Quaternion.Euler(0f, 0, 0f);
                Destroy(GameObject.Find("keySelectUI")); //ui팝업창 죽임
                grabbed = false;
               


            }
        }

    }
}
