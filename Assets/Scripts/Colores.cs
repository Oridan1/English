using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colores : MonoBehaviour {

    [SerializeField]
    GameObject obj;
    [SerializeField]
    Text txt;
    public int count;

    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
           GameObject o = Instantiate(obj,new Vector2(Random.Range(-6, 6), Random.Range(-4, 0)), Quaternion.identity);
            o.GetComponent<ObjetoColor>().game = this;
        }
    }

    void Update()
    {        
        if (count >= 10)
        {
            txt.text = "Game Over";
        }
    }
}
