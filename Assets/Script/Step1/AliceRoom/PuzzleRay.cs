using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRay : MonoBehaviour {

    void rayCasting(Ray ray)
    {
        RaycastHit hitObj;
        if (Physics.Raycast(ray, out hitObj, Mathf.Infinity))
            if (hitObj.transform.tag.Equals("Puzzle2"))
            {
               
                GetComponent<Leap.Unity.Interaction.InteractionSlider>().controlEnabled = false;
                GetComponent<RectTransform>().position = hitObj.transform.gameObject.transform.position; 
               // transform.position = hitObj.transform.gameObject.transform.position;
            }
    }
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = new Ray(GetComponent<RectTransform>().position,  GetComponent<RectTransform>().forward);
        Debug.DrawRay(GetComponent<RectTransform>().position, GetComponent<RectTransform>().forward, Color.green);
        rayCasting(ray);
	}
}