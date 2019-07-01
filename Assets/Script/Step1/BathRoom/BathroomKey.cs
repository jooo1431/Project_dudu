using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomKey : MonoBehaviour {
    bool keyCreated = false;
    [SerializeField]
    GameObject cardKeyPrefab;

    [SerializeField]
    Transform cardKeySpawnPoint;

    public bool triggerOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!keyCreated)
        {
            //인벤토리에 넣어주는 동작-> 
            //사진을 띄우고
            //인벤토리에 넣고
            //열쇠죽이고
            //카드키 생성
            var key = Instantiate(cardKeyPrefab);
            key.transform.position = cardKeySpawnPoint.position;
            keyCreated = true;//instantiate 여러개 되서 한개만 되도록 막아주는역할
            triggerOpen = true; //블라인드 열리게 해주는 flag 역할
        }
        
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
