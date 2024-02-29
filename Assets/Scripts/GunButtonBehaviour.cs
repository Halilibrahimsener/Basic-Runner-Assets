using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GunButtonBehaviour : MonoBehaviour
{



    [SerializeField] GunButtonSettings _gunButtonSetting;
    GameObject[] _gunArray;
    float _closingSpeed;
    GameObject _gun;
    [SerializeField] TextMeshProUGUI _gunNameText;



    void Start()
    {
        _gunArray = _gunButtonSetting.GetGunPrefabArray();
        _closingSpeed = _gunButtonSetting.GetGunButtonClosingSpeed() * Time.deltaTime;

        _gun = ChooseGun();
        _gunNameText.text = _gun.name;

    }



    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(_gun);
            transform.DOMoveY(transform.position.y - 1, 1 / _closingSpeed);
        }
    }

    private GameObject ChooseGun()
    {
        int randomGunIndex = Random.Range(0, _gunArray.Length);
        return _gunArray[randomGunIndex];
    }
}
