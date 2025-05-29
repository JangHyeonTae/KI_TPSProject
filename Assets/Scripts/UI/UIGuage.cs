using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGuage : MonoBehaviour
{

    [SerializeField] Image guageImage;

    public void GetUIGuage(int amount)
    {
        guageImage.fillAmount = amount;
    }
    
}
