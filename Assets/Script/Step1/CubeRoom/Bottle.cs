using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class Bottle : MonoBehaviour
{
    UserData user;

    public Controller controller;
    Frame currentFrame;

   
    Leap.Hand right = null;

    bool handTouched = false;
    bool firstGrab = false;
    bool grabbed = false;
    int falling;
  
    public Material bottleColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Hand"))
        {
            Debug.Log("HandEnteredBottle");
            handTouched = true;
            var fluid = gameObject.transform.GetChild(0);
            bottleColor = fluid.GetComponent<MeshRenderer>().material; //자기병의 색정보 갖고옴
            other.gameObject.GetComponent<Hand>().bottleColor = bottleColor;
        }
    }

   /* void detectHands()  //오른손인지 왼손인지 구별
    {
        //Leap.Hand left = null;
        //Leap.Hand right = null;
        Frame frame = controller.Frame();
        List<Leap.Hand> hands = frame.Hands;
        //Leap.Hand.Equals

        if (hands[0].IsLeft)
        {
            left = hands[0];
            right = hands[1];
        }
        else
        {
            left = hands[1];
            right = hands[0];
        }
        Debug.Log(right.GrabStrength);
    }*/
    // Use this for initialization
    void Start()
    {
        controller = new Controller();
        user = GameObject.Find("UserData").GetComponent<UserData>();
    }

    // Update is called once per frame
    void Update()
    {        
        right = user.MainHand;
        
        if (handTouched)
        {
            if (right.GetFistStrength() > 0.65f && !firstGrab) //처음에만 일로 들어옴
            {
                firstGrab = true;
                grabbed = true;
                Debug.Log("Firstgrabbed");
            }

            while (grabbed)//한번 들어갓다가 바로 나감
            {
                Debug.Log("grabbed");
                transform.parent = GameObject.FindGameObjectWithTag("rightPalm").transform;
                transform.localPosition = new Vector3(0, -0.07f, 0);
                transform.localRotation = Quaternion.Euler(90f, 0, 180f);
                grabbed = false;
                /* if (right.GrabStrength < 0.05f)
                 {
                     grabbed = false;
                     Debug.Log("grabbedFalse");
                 }*/

            }

             if (right.GetFistStrength() < 0.1f)
              {
                     //grabbed = false;
                    transform.parent = null;
                    this.GetComponent<Rigidbody>().isKinematic = false; //바닥 안뚫도록
                    handTouched = false;
                    Debug.Log("grabbedFalse");
              }

           
            

        }

        //잡는순간의 손힘이 0.68보다 크면 쥐어줘(손힘을 줘야 병을 쥘수있다는 효과)
        /* if (handTouched && right.GrabStrength > 0.68f && !grabbed) 
             {
                 transform.parent = GameObject.FindGameObjectWithTag("rightPalm").transform;
                 transform.localPosition = new Vector3(0, -0.05f, 0);
                 transform.localRotation = Quaternion.Euler(90f, 0, 180f);
                 grabbed = true;
             }

         if (grabbed) //이미 잡고있는 상태니까 계속 붙여놔 손에, 
         {
             transform.parent = GameObject.FindGameObjectWithTag("rightPalm").transform;
             transform.localPosition = new Vector3(0, -0.05f, 0);
             transform.localRotation = Quaternion.Euler(90f, 0, 180f);

             //잡고있는 와중에 손힘을 덜주면 떨어지게해
             if (right.GrabStrength < 0.15f)
             {
                 falling++;
             }
             Debug.Log(falling);

             if (falling > 10)
             {
                 grabbed = false;
                 this.GetComponent<Rigidbody>().isKinematic = false; //바닥 안뚫도록
                 handTouched = false;
             }
         }*/




        /*  if (grabbed)
          {
              if (right.GrabStrength < 0.2f)
              {
                  transform.parent = null;
                  this.GetComponent<Rigidbody>().isKinematic = false;
                  handTouched = false;
                  grabbed = false;
              }
          }*/

        /* {
             transform.parent = null;
             this.GetComponent<Rigidbody>().isKinematic = false;
             handTouched = false;
         }*/


        /* else
         {
             transform.parent = null;
             this.GetComponent<Rigidbody>().isKinematic = false;
             handTouched = false;
         }*/
        /*
        if (!handTouched || right.GrabStrength < 0.5f) //트리거가 안됬거나 잡는강도가 0.7보다 적을때
        {
            handTouched = false;
            return;
        }
            
        //트리거가됬고 잡는강도가 0.5보다 높을때

        //if (handTouched)
        //{
            //foreach (var h in controller.Frame().Hands)
           // {

               // if (right.GrabStrength > 0.7f)                  
                //{
                    // 바틀을 palm의 자식으로 넣어서 손에 붙여놓음
                    transform.parent = GameObject.FindGameObjectWithTag("rightPalm").transform;
                    //transform.SetParent(GameObject.FindGameObjectWithTag("rightPalm").transform,true);
                    //Debug.Log("FOund");
                    transform.localPosition = new Vector3(0,0,6f);
                    transform.localRotation = Quaternion.Euler(90f, 0, 180f);
            //  }
            if (right.GrabStrength < 0.6f) //잡고 난 후에 잡는강도가 0.7보다 작은걸로 변할때
        {
                    transform.parent = null;
                    this.GetComponent<Rigidbody>().isKinematic = false;
                    handTouched = false;
                    //this.GetComponent<CapsuleCollider>().isTrigger = false;
                

            }

      //  }*/

    }
}