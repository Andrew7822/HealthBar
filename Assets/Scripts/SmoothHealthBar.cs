using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Image _healthBarSmooth;

    private float _speed = 0.3f;

    private void Awake()
    {
        _healthBarSmooth = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _health.changingHealth += FillHealth;
    }

    private void OnDisable()
    {
        _health.changingHealth -= FillHealth;
    }

    private void FillHealth()
    {
        StartCoroutine(SmoothFill());
    }

    private IEnumerator SmoothFill()
    {
        float trueValue = _health._heroHealth / _health._maxHeroHealth;

        while (Mathf.Abs(_healthBarSmooth.fillAmount - trueValue) > 0.01f)
        {
            _healthBarSmooth.fillAmount = Mathf.MoveTowards(_healthBarSmooth.fillAmount, trueValue, _speed * Time.deltaTime);

            yield return null;
        }
    }
}