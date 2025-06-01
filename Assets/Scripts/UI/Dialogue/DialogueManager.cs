using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private DialogueManager diaInstance;
    public DialogueManager DiaInstance { get { return diaInstance; } }

    private void Awake()
    {
        if (diaInstance == null)
        {
            diaInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
