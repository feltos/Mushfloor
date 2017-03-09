using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    GameObject[] ennemies;
   
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    public void Desactivate()
    {
        foreach(var e in ennemies)
        {
            e.SetActive(false);
        }
    }
}
