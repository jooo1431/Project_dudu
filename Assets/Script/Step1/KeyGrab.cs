using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

//키한테 적용하는 스크립트
public class KeyGrab : MonoBehaviour {


    Leap.Hand userMain;
    UserData user;

    GameObject keySelect;
    bool keyEnter = false;
    bool grabbed = false;
    bool firstGrab = false;
    bool kill = false;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Hand"))
        {
            GameObject.Find("PlayControl").GetComponent<PlayControl>().selectedKey = this.gameObject;
            keyEnter = true;
            Debug.Log("keyselectd");
           // Invoke("killParent",3f);
            
        }
            
                
    }
    void killParent()
    {
        Destroy(keySelect);
        Destroy(GameObject.Find("keySelectUI").gameObject);
    }
   
    // Use this for initialization
    void Start ()
    {
        user = GameObject.Find("UserData").GetComponent<UserData>();
        keySelect = gameObject.transform.parent.gameObject; //현재 키의 부모를 갖고옴, 키 선택하면 죽일거임
    }

    // Update is called once per frame
    void Update()
    {
        
        userMain = user.MainHand;

        if (keyEnter)
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
                kill = true;


            }
        }

        if (kill)
            Invoke("killParent", 1f);
    }
}
