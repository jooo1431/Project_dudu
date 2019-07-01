using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceHand : MonoBehaviour {

    public string puzzleName;

    private void OnTriggerEnter(Collider other)
    {
        //자꾸 딴거까지 트리거에 들어와서 puzzleName이 자꾸 untagged로 되서, 태그이름이puzzle인지 검사해서 맞으면 바꿈
        if (other.gameObject.tag.Substring(0, 6).Equals("Puzzle"))
        {
            Debug.Log("Triggered");
            puzzleName = other.gameObject.tag;
        }
        
        
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
