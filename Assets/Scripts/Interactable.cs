using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{   
    public GameObject panel;
    public GameObject model;
    public Character player;
    public abstract void Interact(GameObject other);

}
