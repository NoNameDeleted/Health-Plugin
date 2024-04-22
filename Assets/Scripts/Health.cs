using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthPoint = 5;

    public UnityEvent<int> OnHealthChange;

    public int MaxHealth => 5;

    public void LoseHealth()
    {
        if (_healthPoint > 0)
        {
            _healthPoint--;
            OnHealthChange?.Invoke(_healthPoint);
        }    
    }

    public void RestoreHealth()
    {
        if (_healthPoint < MaxHealth)
        {
            _healthPoint++;
            OnHealthChange?.Invoke(_healthPoint);
        }   
    }
}
