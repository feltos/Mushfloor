using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesManager : MonoBehaviour
{
    Vector3 OriginPosition;
	
	public void Start ()
    {
        OriginPosition = transform.position;
	}
	
	
	void Update ()
    {
		
	}

    public void Reset()
    {
        transform.position = OriginPosition;
    }
}
