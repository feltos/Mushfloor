using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
   
    private Vector3 offset;    
    public float MinPosX;    
    public float MaxPosX;    
    public float MinPosY;
    public float MaxPosy;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    GameManager gameManager;
   

    void Awake()
    {
        Player = GameObject.Find("Player");
    }

   
    void Start ()
    {
        offset = transform.position - Player.transform.position;
        gameManager.CheckRoom();
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

   
}
