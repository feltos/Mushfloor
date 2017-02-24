using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
   
    private Vector3 offset;
    [SerializeField]
    float MinPosX;
    [SerializeField]
    float MaxPosX;
    [SerializeField]
    float MinPosY;
    [SerializeField]
    float MaxPosy;

    [SerializeField]
    GameObject Player;
    [SerializeField]
    BoxCollider2D PlayerBox;

    

    enum SwitchRoom
    {
        DEFAULT,
        ROOM2,
        ROOM3        
    }
    SwitchRoom SwitchArea = SwitchRoom.DEFAULT;

    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    public void changeSwitchAreaRoom2()
    {
        SwitchArea = SwitchRoom.ROOM2;
        CheckRoom();       
    }

    public void changeSwitchAreaRoom3()
    {
        SwitchArea = SwitchRoom.ROOM3;
        CheckRoom();
    }

    void Start ()
    {
        offset = transform.position - Player.transform.position;
	}

    void Update()
    {
        
    }

    void LateUpdate ()
    {
        Vector3 CameraPosition = Player.transform.position + offset;
        if(CameraPosition.x < MinPosX)
        {
            CameraPosition.x = MinPosX;
        }
        if(CameraPosition.x > MaxPosX)
        {
            CameraPosition.x = MaxPosX;
        }
        if(CameraPosition.y < MinPosY)
        {
            CameraPosition.y = MinPosY;
        }
        if(CameraPosition.y > MaxPosy)
        {
            CameraPosition.y = MaxPosy;
        }
        transform.position = CameraPosition;
	}

   void CheckRoom()
    {
        switch(SwitchArea)
        {
            case SwitchRoom.DEFAULT:
                break;

            case SwitchRoom.ROOM2:
                {
                    MinPosX = 17.39f;
                    MaxPosX = 27.1f;
                    MinPosY = -2.47f;
                    MaxPosy = 2.63f;
                    Player.transform.position = transform.position;
                }
                break;

            case SwitchRoom.ROOM3:
                {
                    MinPosX = -4.61f;
                    MaxPosX = 5.13f;
                    MinPosY = 11.51f;
                    MaxPosy = 16.73f;
                    Player.transform.position = transform.position;
                }
                break;
        }
    }
}
