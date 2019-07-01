using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSelBtn : MonoBehaviour {

    [SerializeField]
    GameObject next;

    UserData user;

    public void LeftBtn()
    {
        user.LeftHandBtn();
        nextBtn();
    }

    public void RightBtn()
    {
        user.RightHandBtn();
        nextBtn();
    }

    void nextBtn()
    {
        next.SetActive(true);
    }

    // Use this for initialization
    void Start ()
    {
        user = GameObject.Find("UserData").GetComponent<UserData>();
        next.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
