using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour {

    /*[SerializeField]
    GameObject CubeRoom;
    [SerializeField]
    GameObject AliceRoom;
    [SerializeField]
    GameObject BathRoom;
    [SerializeField]
    GameObject QuesRoom;*/

    [SerializeField]
    GameObject[] Room;
    [SerializeField]
    string[] roomName;

    public GameObject selectedKey;
    // Use this for initialization
    void Start () //방 일단 다 숨김
    {
      /*  for (int i = 0; i < Room.Length; i++)
        {
            Room[i].SetActive(false);
        }*/

    }

    void ActivateRoom() //선택한 방만 activate
    {
        var name = selectedKey.name.Substring(3, selectedKey.name.Length - 3); //어떤방 선택했는지 추출
        name = name + "Room";
        Debug.Log(name);

        for (int i = 0; i < roomName.Length; i++)
        {
            if (roomName[i].Equals(name))
            {
                Room[i].SetActive(true);
                break;
            }
                
        }
        
    }

	// Update is called once per frame
	void Update ()
    {
        if (selectedKey != null)
            ActivateRoom();
	}
}
