using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    FollowCamera followCamera;
    [SerializeField]
    Room[]Rooms;
   

    public enum SwitchRoom
    {
        DEFAULT,
        ROOM2,
        ROOM3
    }
    public SwitchRoom SwitchArea = SwitchRoom.DEFAULT;

    void Start ()
    {
        SwitchArea = SwitchRoom.DEFAULT;
    }
	
	
	void Update ()
    {
		
	}
  
    public void CheckRoom()
    {
        switch (SwitchArea)
        {
            case SwitchRoom.DEFAULT:
                {
                    followCamera.MinPosX = -4.2f;
                    followCamera.MaxPosX = 3.998743f;
                    followCamera.MinPosY = -2.25f;
                    followCamera.MaxPosy = 2.12631f;                    
                }
                break;

            case SwitchRoom.ROOM2:
                {
                    followCamera.MinPosX = 14.72f;
                    followCamera.MaxPosX = 24.41f;
                    followCamera.MinPosY = -2.56f;
                    followCamera.MaxPosy = 2.55f;                                        
                }
                break;

            case SwitchRoom.ROOM3:
                {
                    followCamera.MinPosX = -3.8f;
                    followCamera.MaxPosX = 3.42f;
                    followCamera.MinPosY = 8.47f;
                    followCamera.MaxPosy = 12.25f;                   
                }
                break;
            
               
        }
        Rooms[(int)SwitchArea].Activate();
        foreach (Room room in Rooms)
        {
            if (room != Rooms[(int)SwitchArea])
                room.Desactivate();
        }
    }

}
