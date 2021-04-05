using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour {

	public void Menu(){
		SceneManager.LoadScene (0);
	}
	public void Office(){
		SceneManager.LoadScene (1);
	}
	public void Conv(){
		SceneManager.LoadScene (2);
	}
	public void GameColor(){
		SceneManager.LoadScene (3);
	}
	public void BusquedaObject(){
		SceneManager.LoadScene (4);
	}
	public void Alphabet(){
		SceneManager.LoadScene (5);
	}
	public void Ob(){
		SceneManager.LoadScene (6);
	}
    public void Oraciones()
    {
        SceneManager.LoadScene(7);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
