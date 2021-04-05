using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameObject : MonoBehaviour {
	public BusquedaObjetos game;
	void OnMouseDown()
	{
        /*if (game.tiempo <= 10) {
			if (gameObject.name == game.nombre) {
				game.puntos++;
				game.tiempo -= 1;
				game.punto.text = game.puntos.ToString ();
				game.Randomizar ();
				StartCoroutine (correcto ());
			}

		} */
        if (game.nombre == name)
        {
            SceneManager.LoadScene(4);
            //game.Randomizar();
        }
	}
	IEnumerator Correcto(){
		game.correcto.text = "Correcto";
		yield return new WaitForSecondsRealtime (2);
		game.correcto.text = "";
	}
}
