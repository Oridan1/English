using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoColor : MonoBehaviour {

    public Colores game;
    bool arrastrando;   
    //Text txt;

	void Awake()
    {
        //txt = GameObject.Find("Texto").GetComponent<Text>();
        int rnd = Random.Range(1, 4);
        switch (rnd)
        {
            case 1:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }
    }

    void Update()
    {
        if (arrastrando)
        {
            var v3 = Input.mousePosition;
            v3.z = 10.0f;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            transform.position = v3;
        }
    }

    void OnMouseDown()
    {
        arrastrando = !arrastrando;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Text>().color == GetComponent<SpriteRenderer>().color)
        {
            game.count++;
            Destroy(gameObject);            
        }
    }
}
