using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OracionesManager : MonoBehaviour {

    List<Oracion> oraciones;
    string respuesta;
    List<string> palabras = new List<string>();
    int indice;
    string[] palabrasCorrectas;
    string respuestaEscrita;
    Text[] botones;

   [SerializeField]
    Text texto;
    [SerializeField]
    Image imagen;
    [SerializeField]
    Transform panel;
	
    void Awake()
    {
        indice = 0;
        TextAsset txt = Resources.Load<TextAsset>("Oraciones");
        ParseJson(txt.text);
        foreach (Oracion o in oraciones)
        {
            string[] auxList = o.oracion.Split(' ');
            for (int i = 0; i < auxList.Length; i++)
            {                
                palabras.Add(auxList[i]);
            }
        }
        Shuffle();
    }

    void Shuffle()
    {
        texto.text = "";
        respuestaEscrita = "";
        indice = 0;
        texto.color = Color.black;
        botones = panel.GetComponentsInChildren<Text>();
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponentInParent<Image>().color = Color.white;
        }
        int rnd = UnityEngine.Random.Range(0, oraciones.Count - 1);
        respuesta = oraciones[rnd].oracion;
        imagen.sprite = Resources.Load<Sprite>("Imagenes/" + oraciones[rnd].imagen);      
        bool[] escritos = new bool[botones.Length];
        palabrasCorrectas = oraciones[rnd].oracion.Split(' ');
        for (int i = 0; i < palabrasCorrectas.Length; i++)
        {
            bool escrito = false;
            while (!escrito)
            {
                int rnd2 = UnityEngine.Random.Range(0, oraciones.Count - 1);
                if (escritos[rnd2] == false)
                {
                    botones[rnd2].text = palabrasCorrectas[i];
                    escritos[rnd2] = true;
                    escrito = !escrito;
                }
            }
        }
        for (int i = 0; i < botones.Length; i++)
        {
            if (escritos[i] == false)
            {
                botones[i].text = palabras[UnityEngine.Random.Range(0, palabras.Count - 1)];
            }
        }
    }

    public void Check(Image boton)
    {
        if (indice < palabrasCorrectas.Length)
        {
            if (boton.GetComponentInChildren<Text>().text == palabrasCorrectas[indice])
            {
                if (indice == 0)
                {
                    respuestaEscrita += palabrasCorrectas[indice];
                }
                else
                {
                    respuestaEscrita += " " + palabrasCorrectas[indice];
                }
                indice++;
                boton.color = Color.green;
                texto.text = respuestaEscrita;
                if (respuestaEscrita == respuesta)
                {
                    StartCoroutine(Ganar());
                }
                for (int i = 0; i < botones.Length; i++)
                {
                    if (botones[i].GetComponentInParent<Image>().color == Color.red)
                    {
                        botones[i].GetComponentInParent<Image>().color = Color.white;
                    }
                }
            }
            else
            {              
                 if (boton.GetComponent<Image>().color != Color.green)
                  {
                     boton.color = Color.red;
                  }
                
            }
        }
    }

    IEnumerator Ganar()
    {
        texto.color = Color.green;
        yield return new WaitForSecondsRealtime(2);
        Shuffle();
    }

    void ParseJson(string dataJson)
    {
        OracionesLoaded oLoaded = JsonUtility.FromJson<OracionesLoaded>(dataJson);
        oraciones = oLoaded.oraciones;
    }

}

[Serializable]
public class OracionesLoaded
{
    public List<Oracion> oraciones;
}

[Serializable]
public class Oracion
{
    public string imagen;
    public string oracion;
}
