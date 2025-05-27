using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager uiInstance;
    public static UIManager UIInstance {  get { return uiInstance; } }

    private void Awake()
    {
        if (uiInstance == null)
        {
            uiInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //private OptionUI optionUI;
    //
    //public OptionUI OptionUI
    //{
    //    get
    //    {
    //        if(optionUI != null)
    //            return optionUI;
    //
    //        optionUI = FindObjectOfType<OptionUI>();
    //        if(optionUI != null)
    //            return optionUI;
    //
    //        OptionUI prefab = Resources.Load<OptionUI>("OptionUI/OptionUI");
    //        return Instantiate(prefab);
    //    }
    //}

    //public T ShowPopUp<T>() where T : BaseUI //in string path -> ui와 스크립트 이름이 다를경우
    //{
    //    T prefab = Resources.Load<T>($"UI/PopUp/{typeof(T).Name}"); //->ui와 스크립트 이름이 다를경우 
    //    T instance = Instantiate(prefab, OptionUI.transform); // UI는 Canvas자식 이어야함
    //    OptionUI.AddUI(instance);
    //    return instance;
    //}
    //
    //public void ClosePopUp()
    //{
    //    OptionUI.RemoveUI();
    //}
}
