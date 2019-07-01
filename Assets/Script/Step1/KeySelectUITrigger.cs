using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySelectUITrigger : MonoBehaviour {

    [SerializeField]
    GameObject keySelectUI;
    [SerializeField]
    GameObject keySelect;

    bool triggerOnce = false;
    /*delegate void changeState();

    SetActive()
    bool SetBool(int input) //1이면 true -1이면 false, SetBool(1)하면 false가 나옴
    {
        input *= -1; //원래 상태를 뒤집어줌 

        if (input == 1)
            return true;
        else
            return false;
    }*/
    
    //UI 위에서 떨어지는 애니메이션 , ******떨어지는 소리넣기********
    private void OnTriggerEnter(Collider other)
    {
        if (!triggerOnce)
        {
            keySelectUI.SetActive(true);
            keySelectUI.GetComponent<Animator>().SetTrigger("Appear");
            Invoke("showKeySelect", 1f); //1초후에 열쇠선택하는 방석 보임, 애니메이샨 끝나는 시간 고려해서 수정필요
            triggerOnce = true;
        }
        
    }

    void showKeySelect()
    {
        keySelect.SetActive(true);
    }


    // Use this for initialization
    void Start ()
    {
        keySelectUI.SetActive(false);
        keySelect.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {       

    }
}
