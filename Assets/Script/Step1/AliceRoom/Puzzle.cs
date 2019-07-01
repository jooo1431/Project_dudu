using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    public bool finished = false;
   // RectTransform
    private void OnTriggerEnter(Collider other)
    {
        string compareName = other.gameObject.GetComponent<AliceHand>().puzzleName;
        if (!finished && compareName.Equals(gameObject.name)) //트리거에 들어온 오브젝트의 태그와 현재 퍼즐의 태그와같다면
        {
            Debug.Log(compareName + "matchfound"+ gameObject.name);
           
            var puzzle = GameObject.FindGameObjectWithTag(gameObject.name);
            Debug.Log(transform.position);
            Debug.Log(puzzle.GetComponent<RectTransform>().anchoredPosition3D);
            puzzle.transform.position = transform.position;
            puzzle.transform.position -= new Vector3(0f, 0f, 100f);
            Debug.Log(transform.position);
            puzzle.GetComponent<Leap.Unity.Interaction.InteractionSlider>().enabled = false;
            puzzle.GetComponent<Rigidbody>().isKinematic = true;
            // puzzle.GetComponent<Leap.Unity.Interaction.InteractionSlider>().controlEnabled = false;
            finished = true;

        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
