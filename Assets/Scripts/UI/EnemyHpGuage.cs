using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpGuage : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Transform cameraTransform;

    //private void Awake() => Init();
    //
    //
    //private void LateUpdate() => SetUIVector(cameraTransform.forward);
    //
    //private void Init()
    //{
    //    cameraTransform = Camera.main.transform;
    //}


    public void SetHpFillAmount(float value)
    {
        _image.fillAmount = value;
    }

    //public void SetUIVector(Vector3 target)
    //{
    //    transform.forward = target;
    //}
}
