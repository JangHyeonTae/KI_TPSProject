using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static UIManager UI => UIManager.UIInstance;
    public static SceneManagers SceneManagers => SceneManagers.SceneInstance;
    public static GameManager GameInstance => GameManager.GameInstance;

    public static InventoryManager InvenInstance => InventoryManager.InvenInstance;
}
