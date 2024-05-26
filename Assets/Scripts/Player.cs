using System;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public static event UnityAction<int> OnHealthChanged;
    public static event UnityAction OnDied; 

    private void Start()
    {
        OnHealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied?.Invoke();
    }
}