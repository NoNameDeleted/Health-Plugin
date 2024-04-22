using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealth : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI.text = _health.MaxHealth.ToString() + "/" + _health.MaxHealth.ToString();
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
        _textMeshProUGUI.text = health.ToString() + "/" + _health.MaxHealth.ToString();
    }
}
