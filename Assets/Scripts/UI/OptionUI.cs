using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
    private Stack<GameObject> stack = new();
    
    public void AddUI(GameObject ui)
    {
        if (stack.Count > 0)
        {
            GameObject top = stack.Peek();
            top.gameObject.SetActive(false);
        }
        stack.Push(ui);
    }

    public void RemoveUI()
    {
        if (stack.Count <= 0) return;

        GameObject top = stack.Pop();
        Destroy(top.gameObject);

        if (stack.Count > 0)
        {
            top = stack.Peek();
            top.gameObject.SetActive(true);
        }
    }
}
