using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Room : MonoBehaviour
{

    [SerializeField]
    GameObject[] GameObjects;

 
	
	void Start ()
    {
        Desactivate();
	}
	
	
	void Update ()
    {
		
	}

    public void Desactivate()
    {
        foreach(var e in GameObjects)
        {
            e.SetActive(false);
        }
    }
    public void Activate()
    {
        foreach (var e in GameObjects)
        {
            e.SetActive(true);
            e.GetComponent<AllEnemiesManager>().Reset();
        }
    }
}
