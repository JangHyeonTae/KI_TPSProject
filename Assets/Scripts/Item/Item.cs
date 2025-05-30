using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : ScriptableObject
{
    public string name;
    public int size;
    public Sprite imageSprite;
    public Image icon; 
    [TextArea]public string description;
    public GameObject model;
    public GameObject dropModel;
    public int Id;

    public bool isAdd;
    

    private void Start()
    {
        icon.sprite = imageSprite;
    }
    
    public virtual void Use(PlayerController player) { }
}
