using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameColor : MonoBehaviour {
	public SpriteRenderer[] sprites;
	public Text texto;
    Color colorverdadero;
	// Use this for initialization
	void Awake(){
        Shuffle();
	}
	
	void Shuffle()
    {
        NodoColor verdadero = RandomColor();
        int random = Random.Range(0, 2);
        SetColor(sprites[random], verdadero);
        sprites[random].name = verdadero.nombre;
        for (int i = 0; i < 3; i++)
        {
            if (i != random)
            {
                NodoColor nc = RandomColor();
                SetColor(sprites[i], nc);
                while (sprites[i].color == sprites[random].color)
                {
                    SetColor(sprites[i], nc);
                }
                sprites[i].name = nc.nombre;
            }

        }
        texto.text = verdadero.nombre;
        colorverdadero = verdadero.color;
    }

	void SetColor(SpriteRenderer sp, NodoColor nc){
		sp.color = nc.color;
	}

    public void Check(SpriteRenderer imagen)
    {
        Debug.Log("Check");
        if (imagen.color == colorverdadero)
        {
            Shuffle();
            Debug.Log("Shuffle");
        }
    }

	NodoColor RandomColor(){
		NodoColor nc = new NodoColor();
		int random = Random.Range (1, 12);
		switch (random) {
		case 1:
			nc.color = Color.white;
			nc.nombre = "White";
			break;
		case 2:
			nc.color = Color.yellow;
			nc.nombre = "Yellow";
			break;
		case 3:
			nc.color = new Color (255, 164, 0);
			nc.nombre = "Orange";
			break;
		case 4:
			nc.color = Color.red;
			nc.nombre = "Red";
			break;
		case 5:
			nc.color = new Color(255,186,253);
			nc.nombre = "Pink";
			break;
		case 6:
			nc.color = new Color(236,6,230);
			nc.nombre = "Purple";
			break;
		case 7:
			nc.color = Color.green;
			nc.nombre = "Green";
			break;
		case 8:
			nc.color = Color.cyan;
			nc.nombre = "Light Blue";
			break;
		case 9:
			nc.color = Color.blue;
			nc.nombre = "Blue";
			break;
		case 10:
			nc.color = new Color(109,67,5);
			nc.nombre = "Brown";
			break;
		case 11:
			nc.color = Color.black;
			nc.nombre = "Black";
			break;
		case 12:
			nc.color = Color.grey;
			nc.nombre = "Grey";
			break;

		}
		return nc;
	}

}

public class NodoColor{
	public Color color;
	public string nombre;
}
