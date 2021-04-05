using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonColor : MonoBehaviour {

    public MinigameColor manager;

    void OnMouseDown()
    {
        manager.Check(GetComponent<SpriteRenderer>());
    }

}
