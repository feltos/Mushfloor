using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Contributeurs : Volgyesi / Secret
public class MenuManager : MonoBehaviour
{

    [SerializeField]
    Button[] MenuButtons;
	
	void Update ()
    {
		
	}

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
