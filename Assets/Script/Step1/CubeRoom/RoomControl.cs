using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {
    
    [SerializeField]
    GameObject exitDoor;

    [SerializeField]
    GameObject[] Bottle;

    public  int coloredBlock; //현재 색칠된 블락수
    public int blockNumMax; //최대 색칠해야되는 블락수
    GameObject ChosenBottle; //쓰일 일 많을거 같아서 골른거 밖으로 빼둠

    void CreateBottleNum()
    {
        int count = Bottle.Length;
        int whichBottle = Random.Range(0, count);
        ChosenBottle = Bottle[whichBottle];
        ChosenBottle.GetComponentInChildren<BottleNumber>().SetMat();
        blockNumMax = ChosenBottle.GetComponentInChildren<BottleNumber>().blockNum;
        
    }

    void Escape()
    {
        if (coloredBlock == blockNumMax)
        {
            exitDoor.GetComponent<Animator>().SetTrigger("DoorOpen");

        }

    }
    // Use this for initialization
    void Start ()
    {
        CreateBottleNum(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        Escape();

    }
}
