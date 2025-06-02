using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public int ID;

    //public Item(string _name, int _size, Sprite _imageSprite, Image _icon, string _description, GameObject _model, GameObject _dropModel)
    //{
    //    name = _name;
    //    size = _size;
    //    imageSprite = _imageSprite;
    //    icon = _icon;
    //    description = _description;
    //    model = _model;
    //    dropModel = _dropModel;
    //}
    private void Start()
    {
        icon.sprite = imageSprite;
    }
    
    public virtual void Use(PlayerController player) { }
}
