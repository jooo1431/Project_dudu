using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class LobbyButton : MonoBehaviour {
    //조명 
    [SerializeField]
    GameObject spotlight_Elev;

    [SerializeField]        
    GameObject spotlight_Stairs;

    Light light;
    private GameObject popupUI;
    bool elevLightOn= false;
    bool stairLightOn = false;

    public void BtnElevator() //버튼 누르면 조명꺼지고 0.6초 뒤에 팝업창 사라짐
    {
        Debug.Log("btnPressed");
        Invoke("HidePopup", 0.02f);
        Invoke("ElevLightOn", 0.05f);      
        Invoke("playSound", 0.05f);

    }
    public void BtnStairs()
    {        
        Invoke("HidePopup", 0.02f);
        Invoke("StairLightOn", 0.05f);
        Invoke("playSound", 0.05f);
    }

    void playSound() //조명 키는 소리
    {
       var sound =  GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sound.PlaySingle(sound.LightOn);

    }

   void StairLightOn()
    {
        spotlight_Stairs.SetActive(true);
        stairLightOn = true;
        /*var light = spotlight_Elev.GetComponent<Light>().spotAngle;
        while (light < 82)
        {
            light += 5;
            spotlight_Elev.GetComponent<Light>().spotAngle = light;
        }*/
    }

    void ElevLightOn()
    {
        spotlight_Elev.SetActive(true);
        //light = spotlight_Elev.GetComponent<Light>();
        elevLightOn = true;
    }


  
    public void HidePopup()
    {
        var popup = GameObject.Find("popupUI");
        Destroy(popup); //팝업 죽임
       // Destroy(gameObject); // 버튼 죽임
    }

    // Use this for initialization
    void Start ()
    {
        //조명 둘다 꺼논다
        //spotlight_Elev.SetActive(false);
        //spotlight_Stairs.SetActive(false);
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (elevLightOn)
        {
            var light = spotlight_Elev.GetComponent<Light>().spotAngle;
            if (light < 79)
            {
                light += 10;
                spotlight_Elev.GetComponent<Light>().spotAngle = light;
            }
        }

        if (stairLightOn)
        {
            var light = spotlight_Stairs.GetComponent<Light>().spotAngle;
            while (light < 82)
            {
                light += 5;
                spotlight_Stairs.GetComponent<Light>().spotAngle = light;
            }
        }
    }
}
