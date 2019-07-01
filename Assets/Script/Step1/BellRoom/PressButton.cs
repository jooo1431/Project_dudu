using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PressButton : MonoBehaviour {

    [SerializeField]
    Text answerText;

    string num;
    

   public void Press()
    {
        //answerText.rectTransform.position.Set(answerText.rectTransform.position.x -11, answerText.rectTransform.position.y, answerText.rectTransform.position.z);
        answerText.text += num;
    }
	// Use this for initialization
	void Start ()
    {
        
        num = this.name; //각자 숫자판에 맞는 숫자가(자기 이름) 들어감
	}
	
}
