using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    private static SceneManagers sceneInstance;
    public static SceneManagers SceneInstance {  get { return sceneInstance; } }

    private void Awake()
    {
        if (SceneInstance == null)
        {
            sceneInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextScene(int curScene)
    {
        if (InventoryManager.InvenInstance != null)
            Destroy(InventoryManager.InvenInstance.gameObject);

        SceneManager.LoadScene(curScene + 1);
    }

}
