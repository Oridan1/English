using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour {

    public Text[] texto;
    public Text topText;
    public List<Nodo> nodos;
    public GameObject padre;
    public Boton[] nombre;

    void Awake()
    {
		TextAsset txt = Resources.Load<TextAsset>("Conversaciones/Conv1/Conv1");
        ParseJson(txt.text);
        texto = padre.GetComponentsInChildren<Text>();
        for (int i = 0; i < texto.Length; i++)
        {
            // texto[i].text = nodos[i].texto;
            // nombre[i].id = nodos[i].id;
            nombre[i].GetNodo(nodos[i]);
        }
    }

	void ParseJson(string dataJson)
    {
        JsonLoaded jsLoaded = JsonUtility.FromJson<JsonLoaded>(dataJson);
        nodos = jsLoaded.nodos;
    }

    public void Respuesta(int id)
    {
        for (int i = 0; i < nodos.Capacity; i++)
        {
            if (nodos[i].id == id)
            {
                for (int j = 0; j < nodos[i].respuestas.Length; j++)
                {
                    nombre[j].GetNodo(GetId(nodos[i].respuestas[j]));
                }
                topText.text = nodos[i].respuesta;
                break;
            }
        }
    }
    private Nodo GetId(int j)
    {
        Nodo nod = new Nodo();
        for (int i = 0; i < nodos.Capacity; i++)
        {
            if (nodos[i].id == j)
            {
                return nodos[i];
            }
        }
        return nod;
    }

    public  void Restart()
    {
        SceneManager.LoadScene(2);
    }

}

[Serializable]
public class JsonLoaded
{
    public List<Nodo> nodos;
    public Status status;
}

[Serializable]
public class Nodo
{
    public int id;
    public string texto;
    public string respuesta;
    public int[] respuestas;
}

[Serializable]
public class Status
{
    public string code;
    public string text;
}