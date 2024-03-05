using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GunButtonBehaviour : MonoBehaviour
{
    [SerializeField] GunButtonSettings _gunButtonSetting;
    [SerializeField] TextMeshPro _gunNameText;
    GunBehaviour[] _gunPrefabArray;   //must be sorted according to _gunType enum
    GunBehaviour _gun;
    float _closingSpeed;

    void Awake()
    {
        _gunPrefabArray = _gunButtonSetting.GetGunPrefabArray();
        _closingSpeed = _gunButtonSetting.GetGunButtonClosingSpeed() * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate<GunBehaviour>(_gun);

            transform.DOMoveY(transform.position.y - 1, 1 / _closingSpeed);
        }
    }

    public void AssignGunType(GunType gunType)
    {
        int gunIndex = (int)gunType;
        _gun = _gunPrefabArray[gunIndex];
        _gunNameText.text = _gun.name;
    }
}
