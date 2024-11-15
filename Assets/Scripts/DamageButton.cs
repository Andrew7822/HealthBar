using System;
using UnityEngine;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    private Button _damageButton;

    public event Action<int> damageHero;

    private int _damagePoints = 20;

    private void Awake()
    {
        _damageButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(ButClick);
    }

    public void ButClick()
    {
        damageHero.Invoke(_damagePoints);
    }
}