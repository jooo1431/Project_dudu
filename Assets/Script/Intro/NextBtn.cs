using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBtn : MonoBehaviour {

    [SerializeField]
    GameObject handSelect;

    [SerializeField]
    GameObject letter;

    int clickCount = 1;

    public void click()
    {
        clickCount++;
        if (clickCount < 2)
            nextStep();
        else
            moveScene();


    }
    
    void moveScene()
    {
        SceneManager.LoadScene("Lobby");
    }

    void nextStep()
    {
        letter.SetActive(true); //letter UI꺼주고 
        handSelect.SetActive(true);//handselect ui 켜준다
    }

    // Use this for initialization
    void Start ()
    {
       handSelect.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
