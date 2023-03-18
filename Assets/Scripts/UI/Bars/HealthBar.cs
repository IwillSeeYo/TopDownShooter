using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        Slider.value = _player.Health;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;

    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}
