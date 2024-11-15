using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Text _healthText;

    private void Awake()
    {
        _healthText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        PrintHealth();
        _health.ChangingHealth += PrintHealth;
    }

    private void OnDisable()
    {
        _health.ChangingHealth -= PrintHealth;
    }

    private void Start()
    {
        PrintHealth();
    }

    private void PrintHealth()
    {
        _healthText.text = _health._heroHealth + "/" + _health._maxHeroHealth + "ея";
    }
}