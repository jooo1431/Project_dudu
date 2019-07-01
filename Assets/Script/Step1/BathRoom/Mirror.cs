using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    [SerializeField]
    ParticleSystem dustParticle;
    static float pSize = 350f;
 

    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem.MainModule pMain = dustParticle.main;
        shrinkSize();     
        pMain.startSize = pSize;      
    }

    void  shrinkSize()
    {
        pSize -= 20f;
    }


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
