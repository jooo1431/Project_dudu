using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class UserData : MonoBehaviour {

    // 사용자가 오른손잡이인지 왼손잡이인지 구분해줄거임
    public Leap.Hand MainHand; //선택, 잡기
    public Leap.Hand SubHand; // 이동

    bool rightHanded = true;
    bool leftHanded = false;

    public void LeftHandBtn()
    {        
        leftHanded = true;
    }

    public void RightHandBtn() //버튼 onclick에 연결
    {
        rightHanded = true;       
    }

   
    // Use this for initialization
    void Awake ()
    {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (leftHanded) //사용자가 왼손잡이면 
        {
            MainHand = Hands.Left;
            SubHand = Hands.Right;
        }


        if (rightHanded) //사용자가 오른손잡이면 
        {
            MainHand = Hands.Right;
            SubHand = Hands.Left;
        }
            
    }
}
