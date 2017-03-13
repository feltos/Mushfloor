using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesManager : MonoBehaviour
{
    public Vector3 OriginPosition;
    public float XP;

	public void Start ()
    {
              
	}
	
	
	void Update ()
    {
     
	}

    public void Reset()
    {        
        transform.position = OriginPosition;
    }
}
