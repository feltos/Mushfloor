using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
   
    private Vector3 offset;    
    float MinPosX;    
    float MaxPosX;    
    float MinPosY;
    float MaxPosy;

    [SerializeField]
    GameObject Player;
   
    
    public enum SwitchRoom
    {
        DEFAULT,
        ROOM2,
        ROOM3        
    }
    public SwitchRoom SwitchArea = SwitchRoom.DEFAULT;

    void Awake()
    {
        Player = GameObject.Find("Player");
    }

   
    void Start ()
    {
        offset = transform.position - Player.transform.position;
        SwitchArea = SwitchRoom.DEFAULT;
        CheckRoom();
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

   public void CheckRoom()
    {
        switch(SwitchArea)
        {
            case SwitchRoom.DEFAULT:
                {
                    MinPosX = -4.2f;
                    MaxPosX = 3.998743f;
                    MinPosY = -2.25f;
                    MaxPosy = 2.12631f;
                }              
                break;

            case SwitchRoom.ROOM2:
                {
                    MinPosX = 14.72f;
                    MaxPosX = 24.41f;
                    MinPosY = -2.56f;
                    MaxPosy = 2.55f;
                    
                }
                break;

            case SwitchRoom.ROOM3:
                {
                    MinPosX = -3.8f;
                    MaxPosX = 3.42f;
                    MinPosY = 8.47f;
                    MaxPosy = 12.25f;                    
                }
                break;
        }
    }
}
