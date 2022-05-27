using System;
using System.Collections;
using Enemy;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;
        private int _currentHealth;
        
        private DeathAbilities _deathAbility;
        public event Action onPlayerDeath;

        private bool _isImmune;
        private float _immuneTime;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        private void Update()
        {
            _immuneTime += Time.deltaTime;
            if (_immuneTime > 0.5f)
            {
                _isImmune = false;
            }
        }

        public void TakeDamage(int damage, DeathAbilities deathAbility)
        {
            if (_isImmune){return;}
            _currentHealth--;
            _immuneTime = 0f;
            if (_currentHealth <= 0)
            {
                if (deathAbility != DeathAbilities.Empty)
                {
                    _deathAbility = deathAbility;
                }
                //Die animation
                Debug.Log("You died! and gained: " + _deathAbility);
                onPlayerDeath?.Invoke();
            }
        }

      
        
    }
}