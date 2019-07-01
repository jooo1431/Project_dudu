using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour {

    [SerializeField]
    string[] answer;

    [SerializeField]
    Text Input;
    [SerializeField]
    GameObject exitDoor;

    [SerializeField]
    GameObject handprint;
    HandPrint handPrint;

     public int anwNum;
    public string temp;
    public bool num = false;
	// Use this for initialization
	void Start ()
    {
        handPrint = handprint.GetComponent<HandPrint>();
       
    }

    /*public void GetAnswer()
    {
        anwNum = handPrint.questNum;
        temp = answer[anwNum];
    }*/
	// Update is called once per frame
	void Update ()
    {
        /*if (num)
        {
            GetAnswer();
        }*/
        //if (handPrint.canGiveAnswer)
          //  getAnswer();
        if (answer[anwNum].Equals(Input.text))
        {
            GameObject.FindGameObjectWithTag("Water").GetComponent<Water>().TriggerDrownStop();
            exitDoor.GetComponent<Animator>().SetTrigger("DoorOpen");
        }

		
	}
}
