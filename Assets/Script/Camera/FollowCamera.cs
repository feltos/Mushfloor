using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
   
    private Vector3 offset;
    [SerializeField]
    float minPosX;
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
        ROOM2        
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
        if(CameraPosition.x < minPosX)
        {
            CameraPosition.x = minPosX;
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
                    minPosX = 17.39f;
                    MaxPosX = 27.1f;
                    MinPosY = -2.47f;
                    MaxPosy = 2.63f;
                    Player.transform.position = transform.position;
                }
                break;
        }
    }
}
