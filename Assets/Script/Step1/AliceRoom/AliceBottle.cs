using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceBottle : MonoBehaviour {

    [SerializeField]
    GameObject exitDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Hand"))
        {
            //**********액체 마시는소리넣기********
            Invoke("destroyBottle", 1.5f);//3초뒤에 병죽임
            //*************뭔가 대변동하는 효과음 넣기******
            Invoke("Shrink", 1f);//3초뒤에 작아짐
            exitDoor.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    void destroyBottle()
    {
        Destroy(gameObject);
    }

    void Shrink()
    {
        var mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        mainCam.transform.position = new Vector3(mainCam.transform.position.x, -716f, mainCam.transform.position.z);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
