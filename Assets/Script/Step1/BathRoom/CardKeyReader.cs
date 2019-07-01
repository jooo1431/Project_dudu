using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardKeyReader : MonoBehaviour {

    [SerializeField]
    GameObject bathroomDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("CardKey"))
        {
            //문열고
            bathroomDoor.GetComponent<Animator>().SetTrigger("DoorOpen");
            //카드키 죽여
            Destroy(other.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
