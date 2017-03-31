using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    FollowCamera followCamera;
    [SerializeField]
    Room[]Rooms;
    public List<PlayerManager.Guns> AvailableGun = new List<PlayerManager.Guns>();
    [SerializeField]
    SpriteRenderer WhiteSquare;
    
   
    float FadeTimer = 0f;
    float FadePeriod = 3f;
    
    
    public enum SwitchRoom
    {
        DEFAULT,
        ROOM2,
        ROOM3,
        ROOM4,
        ROOM5,
        ROOM6,
        ROOM7,
        ROOM8,
        ROOM9,
        ROOM10,
        NONE
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
       
        
    }
  
    

    public void CheckRoom()
    {
       
        switch (SwitchArea)
        {
            case SwitchRoom.DEFAULT:
                {
                    followCamera.MinPosX = -4f;
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
                    followCamera.MinPosX = 34.75f;
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
            case SwitchRoom.ROOM6:
                {
                    followCamera.MinPosX = 34.5f;
                    followCamera.MaxPosX = 43.1f;
                    followCamera.MinPosY = -23.2f;
                    followCamera.MaxPosy = -18.9f;
                }
                break;
            case SwitchRoom.ROOM7:
                {
                    followCamera.MinPosX = 53f;
                    followCamera.MaxPosX = 61.5f;
                    followCamera.MinPosY = -12.82f;
                    followCamera.MaxPosy = -8.4f;
                }
                break;
            case SwitchRoom.ROOM8:
                {
                    followCamera.MinPosX = 53f;
                    followCamera.MaxPosX = 61.5f;
                    followCamera.MinPosY = -23.1f;
                    followCamera.MaxPosy = -19f;
                }
                break;
            case SwitchRoom.ROOM9:
                {
                    followCamera.MinPosX = 34.84f;
                    followCamera.MaxPosX = 41f;
                    followCamera.MinPosY = -38.87f;
                    followCamera.MaxPosy = -30.12f;
                }
                break;
            case SwitchRoom.ROOM10:
                {
                    followCamera.MinPosX = 51.73f;
                    followCamera.MaxPosX = 78.78f;
                    followCamera.MinPosY = -43.95f;
                    followCamera.MaxPosy = -30.76f;
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
    public PlayerManager.Guns ChooseGun()
    {
        int GunIndex = Random.Range(0,AvailableGun.Count);
        PlayerManager.Guns gun = AvailableGun[GunIndex];
        AvailableGun.RemoveAt(GunIndex);
        return gun;
    }

    public void FadeIn()
    {
            WhiteSquare.color = new Color(WhiteSquare.color.r, WhiteSquare.color.g, 
            WhiteSquare.color.b, WhiteSquare.color.a + 1 * Time.deltaTime);
            if (WhiteSquare.color.a >= 1.0f)
            {
                SceneManager.LoadScene(4);
            }
        }
    }
        

