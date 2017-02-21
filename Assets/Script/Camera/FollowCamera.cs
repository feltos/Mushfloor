using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    private Vector3 offset;
    [SerializeField]
    float minPosX;
    [SerializeField]
    float MaxPosX;
    [SerializeField]
    float MinPosY;
    [SerializeField]
    float MaxPosy;

    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    void Start ()
    {
        offset = transform.position - Player.transform.position;
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
}
