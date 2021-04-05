using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Busqueda : MonoBehaviour {

	[SerializeField]
	GameObject[] objetos;   
    public bool[] objetosBool;
	public string nombre;
	public Text objetoTxt;
	public int rnd;


	void Awake()
	{
		Randomizar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Randomizar()
	{
		rnd = Random.Range(0, 5);
        if (objetosBool[rnd] == true)
        {            
            if (objetos[rnd] != null)
            {
                nombre = objetos[rnd].name;
                objetoTxt.text = nombre;
            }          
        }
        else if (CheckArray())
        {
            Randomizar();
        }
        else
        {
            objetoTxt.text = "Game Over";
        }
	}

	bool CheckArray()
	{
		for (int i = 0; i < objetos.Length; i++)
		{
			if (objetosBool[i] == true)
			{
				return true;
			}
		}		
		return false;
	}
}
