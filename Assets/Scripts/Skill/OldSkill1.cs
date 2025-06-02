using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class OldSkill1 : MonoBehaviour
{
    public Skill skill;
    public PlayerController playerController;
    public Image icon;
    public Image imgCool;

    private void Start()
    {
        icon.sprite = skill.icon;

        imgCool.fillAmount = 0;
    }

    public void OnAttack()
    {
        if (imgCool.fillAmount > 0) return;


        StartCoroutine(CoolTime());
    }

    private IEnumerator CoolTime()
    {
        float tick = 1f / skill.cool;
        float t = 0;

        imgCool.fillAmount = 1;

        while (imgCool.fillAmount > 0)
        {
            imgCool.fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }
    }
}
