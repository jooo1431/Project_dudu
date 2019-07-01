using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerPoint : MonoBehaviour {

    [SerializeField]
    GameObject popupUI;

    [SerializeField]
    GameObject lobbyBtn;

    bool once = true;

    private void OnTriggerEnter(Collider other)
    {
        if (once) //트리거 한번만되게함
        {
            Debug.Log("triggered popup");
            Invoke("showUI", 0f);
            once = false;
        }
    }

    void showUI()
    {
        popupUI.SetActive(true);
        lobbyBtn.SetActive(true);
    }
    // Use this for initialization
    void Start ()
    {
        popupUI.SetActive(false);
        lobbyBtn.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
