using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Text _healthText;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _smoothHealthBar;

    private float _health;
    private float _speed = 0.00001f;

    private void Start()
    {
        _health = _maxHealth;
        PrintHealth();
    }

    private void Update()
    {
        PrintHealth();
        StartCoroutine(SmoothFill());
        _healthBar.fillAmount = _health / _maxHealth;
    }

    public void Heal(int amountHealth)
    {
        _health += amountHealth;
    }

    public void TakeDamage(int amountDamage)
    {
        _health -= amountDamage;
    }

    private void PrintHealth()
    {
        _healthText.text = _health + "/" + _maxHealth + "ея";
    }

    private IEnumerator SmoothFill()
    {
        float trueValue = _health / _maxHealth;

        while (Mathf.Abs(_smoothHealthBar.fillAmount - trueValue) > 0.01f)
        {
            _smoothHealthBar.fillAmount = Mathf.MoveTowards(_smoothHealthBar.fillAmount, trueValue, _speed);

            yield return null;
        }
    }
}