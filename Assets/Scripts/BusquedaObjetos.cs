using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BusquedaObjetos : MonoBehaviour {
	public GameObject[] objetos;
    public string[] objs;
	public int puntos;
	public Text punto;
	public Text ObjectTxt;
	public Text correcto;
    public string nombre;
    bool[] bools;

   // public static BusquedaObjetos boManager;

    //public bool correct;
    /*public float tiempo = 0;
	public Text Tiempo; */
   
    void Awake(){
     //   boManager = this;
        bools = new bool[objs.Length];
        for (int i = 0; i < bools.Length; i++)
        {
            bools[i] = false;
        }
        Randomizar();
    }	
	
	void Update () {
		//Timer ();
	}

	public void Randomizar(){
		int rnd = UnityEngine.Random.Range(0, objs.Length-1);
		ObjectTxt.text= objs [rnd];
        nombre = objs[rnd];
        int rnd2 = UnityEngine.Random.Range(0, 5);
        Asignar(objetos[rnd2], rnd);
        for (int i = 0; i < objetos.Length; i++)
        {
            if (i != rnd2)
            {
                int rnd3 = UnityEngine.Random.Range(0, objs.Length - 1);
                while (rnd3 == rnd || bools[rnd3])
                {
                    rnd3 = UnityEngine.Random.Range(0, objs.Length - 1);
                }
                Asignar(objetos[i], rnd3);
                bools[rnd3] = true;
            }
        }
	}

    void Asignar(GameObject go, int index)
    {
        go.name = objs[index];
        go.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objetos/" + objs[index]);
    }

	/*public float Timer(){
		if (tiempo >= 10) {
			Time.timeScale = 1.0f - Time.timeScale;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
		}
		if (Time.timeScale == 1.0f) {
			tiempo = tiempo + 1 * Time.deltaTime;
		}

		int tim = (int)tiempo;
		Tiempo.text = "" + tim.ToString ();
		return tiempo;
	} */
}
