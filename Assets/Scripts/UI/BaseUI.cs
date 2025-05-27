using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    private Dictionary<string, GameObject> gameObjectDic;
    private Dictionary<string, Component> componentDic;

    private void Awake()
    {
        RectTransform[] transforms = GetComponentsInChildren<RectTransform>(true);
        gameObjectDic = new Dictionary<string, GameObject>(transforms.Length * 4);
        foreach (RectTransform child in transforms)
        {
            gameObjectDic.TryAdd(child.gameObject.name, child.gameObject);
        }

        Component[] components = GetComponentsInChildren<Component>(true);
        componentDic = new Dictionary<string, Component>(components.Length * 4);
        foreach (Component com in components)
        {
            componentDic.TryAdd($"{com.gameObject.name}_{com.GetType().Name}",com);
        }
    }

    public GameObject GetUI(in string name)
    {
        gameObjectDic.TryGetValue(name,out GameObject gameObject);
        return gameObject;
    }

    public T GetUI<T>(in string name) where T : Component
    {
        componentDic.TryGetValue($"{name}_{typeof(T).Name}", out Component component);
        return component as T;
    }

    public PointerHandler GetEvent(in string name)
    {
        GameObject gameObject = GetUI(name);
        return gameObject.GetOrAddComponent<PointerHandler>();
    }
}
