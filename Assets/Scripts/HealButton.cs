using System;
using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    private Button _healButton;

    public event Action<int> healHero;

    private int _healPoints = 20;

    private void Awake()
    {
        _healButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _healButton.onClick.AddListener(ButClick); 
    }

    public void ButClick()
    {
        healHero.Invoke(_healPoints);
    }
}