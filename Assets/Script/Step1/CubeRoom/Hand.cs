using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    //public Color bottleColor;
    public Material bottleColor;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Bottle"))
        {
            Debug.Log("triggered");
            var fluid = other.gameObject.transform.GetChild(0);
            bottleColor = fluid.GetComponent<MeshRenderer>().material; //병의 색정보를 손스크립트로 옮겨옴
            //Debug.Log(bottleColor);
          
        }
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
