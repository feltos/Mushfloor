using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;

public class CréditsManager : MonoBehaviour
{

    float TimeBeforeLeave = 0f;
    float CooldownBeforeLeave = 2f;
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        TimeBeforeLeave += Time.deltaTime;
        if(TimeBeforeLeave >= CooldownBeforeLeave && InputManager.AnyKeyIsPressed)
        {
            SceneManager.LoadScene(0);
        }
	}
}
