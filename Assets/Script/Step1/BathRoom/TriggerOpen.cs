using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpen : MonoBehaviour {

    [SerializeField]
    GameObject blind;

    [SerializeField]
    GameObject Key;

    BathroomKey KeyScript;

    private void OnTriggerEnter(Collider other)
    {
        //블라인드 열림
        if(KeyScript.triggerOpen)
               blind.GetComponent<Animator>().SetTrigger("BlindOpen");

    }
    // Use this for initialization
    void Start ()
    {
        KeyScript = Key.GetComponent<BathroomKey>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
