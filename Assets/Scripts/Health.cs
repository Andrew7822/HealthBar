using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealButton _healButton;
    [SerializeField] private DamageButton _damageButton;

    public event Action ChangingHealth;

    public float _maxHeroHealth { get; private set; }

    public float _heroHealth { get; private set; }

    private void OnEnable()
    {
        _healButton.healHero += Heal;
        _damageButton.damageHero += TakeDamage;
    }

    private void OnDisable()
    {
        _healButton.healHero -= Heal;
        _damageButton.damageHero -= TakeDamage;
    }

    private void Awake()
    {
        _maxHeroHealth = 100;
        _heroHealth = _maxHeroHealth;
    }

    public void Heal(int amountHealth)
    {
        _heroHealth += amountHealth;
        ChangingHealth.Invoke();
    }

    public void TakeDamage(int amountDamage)
    {
        _heroHealth -= amountDamage;
        ChangingHealth.Invoke();
    }
}