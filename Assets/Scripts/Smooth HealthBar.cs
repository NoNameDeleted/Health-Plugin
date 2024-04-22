using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speedChange = 1;

    private Slider _slider;
    private Coroutine _currentChangeing;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.MaxHealth;
    }
    private void OnEnable()
    {
        _health.OnHealthChange.AddListener(UpdateHealth);
    }

    private void OnDisable()
    {
        _health.OnHealthChange.RemoveListener(UpdateHealth);
    }

    private void UpdateHealth(int health)
    {
        if (_currentChangeing != null)
        {
            StopCoroutine(_currentChangeing);
        }

        _currentChangeing = StartCoroutine(SmoothHealthChange(health));

    }

    private IEnumerator SmoothHealthChange(int health)
    {
        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speedChange * Time.deltaTime);

            yield return null;
        }
    }
}
