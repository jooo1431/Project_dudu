using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

//손을 인식해서 카메라를 이동시키는거임 , 그래서 이 스크립트 카메라에 적용
public class ControlMove : MonoBehaviour {

    UserData user;
    Leap.Hand userSub;

    float speed = 25f;

    // Use this for initialization
    void Start ()
    {
        user = GameObject.Find("UserData").GetComponent<UserData>();
	}
    bool FowardMove()
    {

        bool error = true;

        Finger thumb = Hands.GetThumb(userSub);
        Finger index = Hands.GetIndex(userSub);
        Finger middle = Hands.GetMiddle(userSub);
        Finger ring = Hands.GetRing(userSub);
        Finger pinky = Hands.GetPinky(userSub);


        if (index.IsExtended && thumb.IsExtended && !middle.IsExtended && !ring.IsExtended && !pinky.IsExtended)
        {
            if (index.Direction.y < 0)
            {
                error =  true;
            }
            else
                error = false;
        }

        if (error)
            return false;
        else
            return true;
    }
    private bool BackwardMove()
    {
        float grab = userSub.GrabStrength;
        bool error = false;
        List<Finger> fingerList = userSub.Fingers;// new List<Finger>();

        if (grab > 0.9)
        {
            foreach (Finger finger in fingerList)
            {
                if (finger.IsExtended)
                {
                    error = true;
                    break;
                }
            }

        }
        else
            error = true;


        if (error)
            return false;
        else
            return true;        
    }
	// Update is called once per frame
	void Update () {

        userSub = user.SubHand; //현재프레임의 오른손 받아옴 

        //transform.position.z;

        if (BackwardMove()) 
            transform.Translate(new Vector3(0, 0, -1 * speed * Time.deltaTime));

        if (FowardMove())
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

























        /* controller = new Controller();
         Frame frame = controller.Frame();
         List<Leap.Hand> hands = frame.Hands; //list of hands detected in a arbitrary order
         if (frame.Hands.Count > 0) //손이 하나라도 감지가 된다면
         {
             Leap.Hand fristHand = hands[0]; // 왼손 또는 오른손중 하나만 연결
         }
         //hands[0].GetPalmPose()
         HandPalmPitch = hands[0].PalmNormal.Pitch;
         HandPalmRoll = hands[0].PalmNormal.Roll;
         HandPalmYaw = hands[0].PalmNormal.Yaw;

         HandWristRot = hands[0].WristPosition.Pitch;*/

        //Debug.Log("Pitch :" + HandPalmPitch);
        // Debug.Log("Roll :" + HandPalmRoll);
        //Debug.Log("Yaw : " + HandPalmYaw);

        //Move


        /*if ((HandPalmYaw > -1.2f && HandPalmYaw < 0) || (HandPalmYaw > 1.9f && HandPalmYaw < 3))//yaw값 사용하여 오른쪽으로 이동
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else if (HandPalmYaw < -2.2f || (HandPalmYaw > 0 && HandPalmYaw <1.1f)) //yaw값 사용하여 왼쪽으로 이동
        {
            transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
        }*/

        /* if (HandPalmYam > -2f && HandPalmYam < 3.5f)
         {
             transform.Translate(new Vector3( speed * Time.deltaTime,0,0));
         }
         else if (HandPalmYam < -2.2f)
         {
             transform.Translate(new Vector3(-1* speed * Time.deltaTime,0,0));
         }*/


        /*
        if (HandPalmPitch > -2f && HandPalmPitch < 3.5f)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        else if (HandPalmPitch < -2.2f)
        {
            transform.Translate(new Vector3(0, 0, -1 * speed * Time.deltaTime));
        }
        */

    }
}
