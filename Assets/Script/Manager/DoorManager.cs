using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

   
 
    public enum DoorOrientation { VERTICAL, HORIZONTAL};
    [SerializeField]
    DoorOrientation doorOrientation;

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
                {
                    if (Player.transform.position.y - transform.position.y > 0)
                    {
                        Player.transform.position = transform.position + (Vector3.down * 3);
                    }
                    else
                    {
                        Player.transform.position = transform.position + (Vector3.up * 3);
                    }
                }
                break;
            case DoorOrientation.HORIZONTAL:
                {
                    if (Player.transform.position.x - transform.position.x > 0)
                    {
                        Player.transform.position = transform.position + (Vector3.left * 3);
                    }
                    else
                    {
                        Player.transform.position = transform.position + Vector3.right * 3;
                    }
                    break;
                }
            }
    }
}
