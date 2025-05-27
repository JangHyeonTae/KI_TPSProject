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

    public void SceneLoad()
    {
        SceneManager.LoadScene("Level1");
    }

    public void FinishScene()
    {
        //SceneManager.LoadScene(2);
    }
}
