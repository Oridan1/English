using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour {
	public Text texto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseEnter(){
		GetComponent<SpriteRenderer> ().color = Color.yellow;
		texto.text = gameObject.name;
	}
	void OnMouseExit(){
		GetComponent<SpriteRenderer> ().color = Color.white;
		texto.text = "";
	}
}
