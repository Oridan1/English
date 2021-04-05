using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton : MonoBehaviour {
        public int id;
    public ManagerScript o;
	public GameObject txt;

    bool playing;

    // Use this for initialization
	void Awake(){
        playing = false;
		txt.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("Conversaciones/Conv1/Conv1_inicio");
		txt.GetComponent<AudioSource> ().Play ();
	}
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click()
    {
        if (!playing)
        {
            playing = true;
            StartCoroutine(Cargar());
            txt.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Conversaciones/Conv1/Conv1_respuesta_" + id.ToString());
        }
    }

    IEnumerator Cargar()
    {       
        GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(GetComponent<AudioSource>().clip.length);
		o.Respuesta(id);

		StartCoroutine (Respuesta ());

    }
	IEnumerator Respuesta()
	{		
		txt.GetComponent<AudioSource> ().Play ();
		if (txt.GetComponent<AudioSource> ().clip) {
			yield return new WaitForSecondsRealtime (txt.GetComponent<AudioSource> ().clip.length);
            playing = false;
        }
	}

    public void GetNodo(Nodo nodo)
    {
        id = nodo.id;
        GetComponentInChildren<Text>().text = nodo.texto;
		GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("Conversaciones/Conv1/Conv1_texto_" + id.ToString());
    }
}
