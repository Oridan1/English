using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonScript : MonoBehaviour {

	[SerializeField]
	string nivel;

	void OnMouseDown()
	{
		SceneManager.LoadScene(nivel);
	}
}
