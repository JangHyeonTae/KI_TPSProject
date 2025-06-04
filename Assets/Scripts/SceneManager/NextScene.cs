using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public int curScene;

    public void LoadNext(int cur)
    {
        Manager.SceneManagers.LoadNextScene(cur + 1);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            LoadNext(curScene);
        }
    }
}
