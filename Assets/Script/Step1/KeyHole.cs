using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour {

    private void OnTriggerEnter(Collider other) //열쇠 들어가면 문 열려야함
    {
        if (other.tag.Equals("Key"))
        {
            var name = other.name.Substring(3, other.name.Length - 3); //어떤방 선택했는지 추출
            name = name + "Door";
            //열쇠에 알맞는 문 찾아서 오픈
            GameObject.Find(name).GetComponent<Animator>().SetTrigger("Open");

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
