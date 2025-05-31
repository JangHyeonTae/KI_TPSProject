using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpGuageUI : MonoBehaviour
{

    [SerializeField] Image hpGuage;

    public void HPGuageUI(float amount)
    {
        hpGuage.fillAmount = amount;
    }
}
