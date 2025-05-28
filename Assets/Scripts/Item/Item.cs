using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : ScriptableObject
{
    public string name;
    public int size;
    public Image icon; 
    [TextArea]public string description;
    public GameObject model;
    public GameObject dropModel;

    public bool isAdd;
    
    
    public virtual void Use(PlayerController player) { }
}
