using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour {

	public Busqueda game;

	void OnMouseDown()
	{
		if (gameObject.name == game.nombre)
		{
            Destroy(gameObject);
            game.objetosBool[game.rnd] = false;
            game.Randomizar();
        }
    }
}    

