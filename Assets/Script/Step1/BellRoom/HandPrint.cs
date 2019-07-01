using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPrint : MonoBehaviour {

    [SerializeField]
    GameObject waterPrefab;

    Transform waterStartPos;

    [SerializeField]
    Sprite[] QuestUI;
    [SerializeField]
    Sprite[] HintUI;
    

    [SerializeField]
    GameObject questionPrefab;
    [SerializeField]
    GameObject hintPrefab;
    [SerializeField]
    GameObject numBoard;

    
   
    SphereCollider collider;
    Water waterScript;
    Answer answerScript;

    

    public int questNum;
    bool triggeredOnce = false;
  
    //private Transform q_Trans;
   
   
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("Hand"))
        {
            Debug.Log("triggered");
            //questNum = Random.Range(0, QuestUI.Length);
            
            //문제
            questionPrefab.GetComponent<SpriteRenderer>().sprite = QuestUI[questNum];
            questionPrefab.SetActive(true);
            questionPrefab.gameObject.GetComponent<Animator>().SetTrigger("start");
            //숫자판
            numBoard.SetActive(true);
           
            numBoard.gameObject.GetComponent<Animator>().SetTrigger("Appear");
           
            DrownStart();
            answerScript.anwNum = questNum;
            //triggeredOnce = true;
            
            //물
            
        }        
    }
    void detectTrigger()
    {
        if (triggeredOnce)
            collider.isTrigger = false;
    }

   
    /*public int giveAnswerNum()
    {        
        return questNum;
       
    }*/

    public void giveHint()
    {
        hintPrefab.SetActive(true);
        hintPrefab.GetComponent<SpriteRenderer>().sprite = HintUI[questNum];       
    }

    void DrownStart()
    {
        if (!triggeredOnce)
        {
            var water = Instantiate(waterPrefab) as GameObject;
            water.transform.position = waterStartPos.position;
            waterScript = water.GetComponent<Water>();
            waterScript.Timer(); //물에 적용된 타이머시작
            triggeredOnce = true;
        }
    }

    // Use this for initialization
    void Start ()
    {
        //문제
        questNum = Random.Range(0, QuestUI.Length);
        questionPrefab.SetActive(false);
        //힌트
        hintPrefab.SetActive(false);
        //숫자판
        //numBoard = GameObject.Find("NumBoard");
        numBoard.SetActive(false);
       
        waterStartPos = GameObject.FindGameObjectWithTag("WaterStartPos").transform;
        answerScript = GameObject.FindGameObjectWithTag("Answer").GetComponent<Answer>();

        collider = this.gameObject.GetComponent<SphereCollider>();
       
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        //detectTrigger();

    }
}
