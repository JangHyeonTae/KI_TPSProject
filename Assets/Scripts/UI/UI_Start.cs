using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Start : BaseUI
{
    public void LoadNexScene()
    {
        Manager.SceneManagers.SceneLoad();
    }
}
