using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    Animator m_animator;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touched");
        m_animator.SetTrigger("OpenDoor");

    }

    /*private void OnTriggerExit(Collider other)
    {
        Invoke("CloseDoor", 8);
    }*/

    void PauseDoorAnim()
    {
        m_animator.enabled = false;
        Invoke("CloseDoor", 15);
    }

    /*public void OpenDoor()
    {
        Debug.Log("Touched");
        m_animator.SetTrigger("OpenDoor");
    }*/


    /*public void CloseDoorInvoke()
    {
        Invoke("CloseDoor", 8);
    }*/

    public void CloseDoor()
    {
        m_animator.enabled = true;

    }
    // Use this for initialization
    void Start ()
    {
        m_animator = gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
