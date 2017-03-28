using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    FollowCamera followCamera;
    [SerializeField]
    Room[]Rooms;
    public List<PlayerManager.Guns> AvailableGun = new List<PlayerManager.Guns>();
      
    
    public enum SwitchRoom
    {
        DEFAULT,
        ROOM2,
        ROOM3,
        ROOM4,
        ROOM5
    }
    public SwitchRoom SwitchArea = SwitchRoom.DEFAULT;

    void Start ()
    {
        SwitchArea = SwitchRoom.DEFAULT;
        for(int i = (int)PlayerManager.Guns.Shotgun;i < (int)PlayerManager.Guns.Length;i++)
        {
            AvailableGun.Add((PlayerManager.Guns)i);
        }
    }
	
	
	void Update ()
    {
        DontDestroyOnLoad(gameObject);
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
                    followCamera.MaxPosy = 2.55f;                    
                }
                break;

            case SwitchRoom.ROOM2:
                {
                    followCamera.MinPosX = 14.72f;
                    followCamera.MaxPosX = 23.6f;
                    followCamera.MinPosY = -2.20f;
                    followCamera.MaxPosy = 2.55f;                                        
                }
                break;

            case SwitchRoom.ROOM3:
                {
                    followCamera.MinPosX = 35.25f;
                    followCamera.MaxPosX = 42f;
                    followCamera.MinPosY = -2.20f;
                    followCamera.MaxPosy = 2.55f;                   
                }
                break;
            case SwitchRoom.ROOM4:
                {
                    followCamera.MinPosX = 34.02f;
                    followCamera.MaxPosX = 42f;
                    followCamera.MinPosY = -12.67f;
                    followCamera.MaxPosy = -8.15f;
                }
                break;

            case SwitchRoom.ROOM5:
                {
                    followCamera.MinPosX = 15.1f;
                    followCamera.MaxPosX = 23.79f;
                    followCamera.MinPosY = -12.67f;
                    followCamera.MaxPosy = -8.15f;
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
