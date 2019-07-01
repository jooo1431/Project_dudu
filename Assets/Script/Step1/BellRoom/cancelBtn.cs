using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cancelBtn : MonoBehaviour {

    [SerializeField]
    Text Answer;

    public void Press()
    {
        string temp = Answer.text;
        temp = temp.Substring(0, temp.Length - 1);
        Answer.text = temp;
        //Answer.text = Answer.text.Substring(0, Answer.text.Length - 1);

    }
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
