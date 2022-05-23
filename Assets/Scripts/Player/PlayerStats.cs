using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;
        private int _currentHealth;
        public event Action onPlayerDeath;

        private void Start()
        {
            _currentHealth = maxHealth;
        }


        public void TakeDamage()
        {
            _currentHealth--;
            if (_currentHealth <= 0)
            {
                //Die animation
                Debug.Log("You died!");
                onPlayerDeath?.Invoke();
            }
        }

      
        
    }
}