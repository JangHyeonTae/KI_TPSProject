using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public int curScene;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Manager.SceneManagers.LoadNextScene(curScene);
        }
    }
}
