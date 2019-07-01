using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towel3Mid : MonoBehaviour {

    Animator m_animator;

    private void OnTriggerEnter(Collider other)
    {

        m_animator.SetTrigger("Mid");
        Invoke("gotoIdle", 1f);
    }

    void gotoIdle()
    {
        m_animator.SetTrigger("Idle");
    }
    // Use this for initialization
    void Start()
    {
        m_animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
