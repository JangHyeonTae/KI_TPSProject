using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGuage : MonoBehaviour
{

    [SerializeField] Image bagGuageImage;
    [SerializeField] TextMeshProUGUI bagText;

    [SerializeField] Image powerGuage;

    [SerializeField] TextMeshProUGUI itemDsc;

    public void BagGuageUI(float value)
    {
        Debug.Log($"UI : {value}");
        bagGuageImage.fillAmount = value;
        float bagValue = value * Manager.InvenInstance.maxSum;
        bagText.text = bagValue.ToString();
    }

    public void PowerGuageUI(PlayerStatus status, Weapon weapon = null)
    {
        powerGuage.fillAmount = (status.curPower + weapon.value)/100;
    }
    

    private void ItemDsc(Item item)
    {
        itemDsc.text = item.description;
    }

}
