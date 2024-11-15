using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Image _healthBar;

    private void Awake()
    {
        _healthBar = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _health.ChangingHealth += fillAmountHealth;
    }

    private void OnDisable()
    {
        _health.ChangingHealth -= fillAmountHealth;
    }

    private void fillAmountHealth()
    {
        _healthBar.fillAmount = _health._heroHealth / _health._maxHeroHealth;
    }
}