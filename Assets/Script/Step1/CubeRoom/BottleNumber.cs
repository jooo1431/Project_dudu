using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleNumber : MonoBehaviour {

    MeshRenderer m_meshRenderer;
    [SerializeField]
    Material[] matNums;

    
    public int blockNum;

    public void SetMat()
    {
        int numMax = matNums.Length;
        int randNum = Random.Range(0, numMax); //밖에서 넣어준 이미지파일 개수 카운트해서 랜덤으로 뿌릴 이미지를결정
        blockNum = randNum + 1; //바닥에 써있는 숫자임
        m_meshRenderer.material = matNums[randNum]; // 그 숫자가 이제 병밑에 보임
    }
    
	// Use this for initialization
	void Start ()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
                                                                                          