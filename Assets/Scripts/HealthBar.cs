using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

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
        _slider.value = health;
    }
}
