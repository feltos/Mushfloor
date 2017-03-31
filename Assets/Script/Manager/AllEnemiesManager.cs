using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Contributeurs : Volgyesi

public class AllEnemiesManager : MonoBehaviour
{
    Vector3 OriginPosition;
    public Room room;

	protected virtual void Start()
    {
        Init();
	}
	
	
	void Update ()
    {
     
	}

    public void Reset()
    {        
        transform.position = OriginPosition;
    }
    public void Init()
    {
        OriginPosition = transform.position;
    } 
}
