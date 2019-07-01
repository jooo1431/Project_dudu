using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEnter : MonoBehaviour {

    [SerializeField]
    GameObject AliceCamera;
    [SerializeField]
    GameObject mainScreen;
    [SerializeField]
    GameObject Puzzle;
    [SerializeField]
    GameObject Bottle;

    Camera mainCamS;
    Camera aliceCamS;
    Puzzle[] plist;
    bool startGame;
    bool endGame;
    bool[] gameState;

    Transform mainCamTransform;
    float mainCamFov;
    float mainCamFarPlane;
    float mainCamNearPlane;

    //코인 들어오면 코인 죽dlrh -> 게임하도록 카메라 이동
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Coin"))
        {            
            Destroy(other.gameObject);
            MoveCamera();
            PlayGame();
        }
    }

    //카메라 전환
    void MoveCamera()
    {
        //메인카메라 정보저장
        var mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamS = mainCam.GetComponent<Camera>();
        mainCamTransform = mainCam.transform; //메인 카메라위치저장
        mainCamFov = mainCamS.fieldOfView;
        mainCamFarPlane = mainCamS.farClipPlane;
        mainCamNearPlane = mainCamS.nearClipPlane;

        //메인카메라를 앨리스 카메라로 세팅
        mainCam.transform.position = AliceCamera.transform.position;
        mainCam.transform.rotation = AliceCamera.transform.rotation;
        mainCam.GetComponent<Camera>().fieldOfView = aliceCamS.fieldOfView;
        mainCam.GetComponent<Camera>().farClipPlane = aliceCamS.farClipPlane;
        mainCam.GetComponent<Camera>().nearClipPlane = aliceCamS.nearClipPlane;

    }

    //카메라 원상복구
    void ResetCamera()
    {
        var mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        mainCam.transform.position = mainCamTransform.position;
        mainCam.transform.rotation = mainCamTransform.rotation;
        mainCam.GetComponent<Camera>().fieldOfView = mainCamFov;
        mainCam.GetComponent<Camera>().farClipPlane = mainCamFarPlane;
        mainCam.GetComponent<Camera>().nearClipPlane = mainCamNearPlane;
    }

    //게임실행
    void PlayGame()
    {
        mainScreen.SetActive(false);//카메라 전환후 메인스크린 off
        Destroy(mainScreen.transform.GetChild(0).gameObject); //시작화면 죽임
        Invoke("playPuzzleAnim", 1f); //answer판만 보이는 상에서 퍼즐 애니메이션 재생
        startGame = true;
    }

    void playPuzzleAnim()
    {
        Puzzle.gameObject.GetComponent<Animator>().SetTrigger("Appear");
    }

    //끝난화면 띄우고 효과음 넣어주고 카메라 원상복귀 시캬주고 물병나오게하고 
    void EndGame()
    {
        mainScreen.SetActive(true); //메인스크린 다시 on
        mainScreen.transform.GetChild(0).gameObject.SetActive(true);//종료화면 on
        //밑에서물병 나오는소리 삽입
        Bottle.SetActive(true); //물병 생성
    }


  

    // Use this for initialization
    void Start ()
    {
        aliceCamS = AliceCamera.GetComponent<Camera>();
        plist = Puzzle.GetComponentsInChildren<Puzzle>();
        gameState = new bool[4];
        mainScreen.transform.GetChild(1).gameObject.SetActive(false);
        Bottle.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (startGame)
        {
            for (int i = 0; i < plist.Length; i++)
            {
                if (plist[i].finished != gameState[i])
                    gameState[i] = true;
            }

            if (gameState[0] == true && gameState[1] == true && gameState[2] == true && gameState[3] == true)
            {
                Debug.Log("Game Success");
                startGame = false; //게임을 끝냄
                endGame = true;
            }
        }

            if (endGame)//게임이 끝났다면 카메라 원상태로 복귀
            {
                EndGame();
                ResetCamera();
                Debug.Log("Camera Reset");
                endGame = false;
            }        
        
	}
}
