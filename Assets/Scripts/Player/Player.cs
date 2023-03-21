using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private AudioSource _audioSource;

    public Weapon CurrentWeapon => _currentWeapon;
    public int Health => _health;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
        _currentWeapon = _weapons[0];
        _audioSource = GetComponent<AudioSource>();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        _audioSource.Play();
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }
}