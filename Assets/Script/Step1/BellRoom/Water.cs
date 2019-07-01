using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    //[SerializeField]
    //Transform WaterMaxPos;
    GameObject maxDepth;
    GameObject minDepth;
    //float maxDepth = 7548f;
    float speed = 3f;
    bool triggerDrownStop = false;
    bool triggerDrownStart = false;

    float timer;

    public void Timer()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 10f)
        {
            GameObject.FindGameObjectWithTag("HandPrint").GetComponent<HandPrint>().giveHint();
            TriggerDrownStart();
        }

    }
    public void TriggerDrownStart()
    {
        triggerDrownStart = true;
    }
    void DrownStart()
    {
        if (transform.position.y < maxDepth.transform.position.y)
        {
            transform.position += Vector3.up * 0.5f * Time.deltaTime;
        }
    }

    public void TriggerDrownStop()
    {
        triggerDrownStop = true;
    }

    void DrownStop()
    {
        if (transform.position.y > minDepth.transform.position.y)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
    }
    // Use this for initialization
    void Start ()
    {
        maxDepth = GameObject.FindGameObjectWithTag("WaterMaxPos");
        minDepth = GameObject.FindGameObjectWithTag("WaterStartPos");

    }
	
	// Update is called once per frame
	void Update () {

        if (triggerDrownStop)
            DrownStop();

        if (triggerDrownStart)
            DrownStart();

        Timer();


    }
}
