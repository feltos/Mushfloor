using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{


    [SerializeField]
    GameManager gameManager;
    public enum DoorOrientation { VERTICAL, HORIZONTAL};
    [SerializeField]
    DoorOrientation doorOrientation;
    [SerializeField]
    GameManager.SwitchRoom RoomUP;
    [SerializeField]
    GameManager.SwitchRoom RoomDown;
    [SerializeField]
    GameManager.SwitchRoom RoomLeft;
    [SerializeField]
    GameManager.SwitchRoom RoomRight;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
    public void MovePlayer(PlayerManager Player)
    {
        switch(doorOrientation)
        {
        case DoorOrientation.VERTICAL:
                
                if (Player.transform.position.y - transform.position.y > 0)
                {
                    Player.transform.position = transform.position + (Vector3.down * 3);
                    gameManager.SwitchArea = RoomDown;
                        
                }
                else
                {
                    Player.transform.position = transform.position + (Vector3.up * 3);
                    gameManager.SwitchArea = RoomUP;
                }
                
                break;
        case DoorOrientation.HORIZONTAL:
                
            if (Player.transform.position.x - transform.position.x > 0)
            {
                Player.transform.position = transform.position + (Vector3.left * 3);
                gameManager.SwitchArea = RoomLeft;
            }
            else
            {
                Player.transform.position = transform.position + Vector3.right * 3;
                gameManager.SwitchArea = RoomRight;
            }
            break;
                
        }
        gameManager.CheckRoom();
    }
}
