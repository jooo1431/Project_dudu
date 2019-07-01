using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {

    Material blockMat;
    RoomControl roomControl;
    bool colored = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!colored && roomControl.coloredBlock < roomControl.blockNumMax)
        {
            if (other.gameObject.tag.Equals("Hand"))
            {
                    Debug.Log("block colored");
                    blockMat.color = other.gameObject.GetComponent<Hand>().bottleColor.color;
                    colored = true;
                    CountColoredBlock();
               
            }
        }
        
       
    }

    void CountColoredBlock()
    {
        if(colored)
        roomControl.coloredBlock++;
    }
    // Use this for initialization
    void Start ()
    {
        blockMat= GetComponent<MeshRenderer>().material; //시작하면 블록(자기자신)의 material에 접근
        roomControl = GameObject.Find("RoomControl").GetComponent<RoomControl>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
