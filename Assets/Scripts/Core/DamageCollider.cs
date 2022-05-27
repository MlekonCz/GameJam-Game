using Enemy;
using Player;
using UnityEngine;

namespace Core
{
    public class DamageCollider : MonoBehaviour
    {
        private Collider2D _damageCollider;
        [SerializeField] private int currentWeaponDamage = 1;

        private bool _isSword = false;
        private bool _isShield = false;
        
        private void Awake()
        {
            _damageCollider = GetComponent<Collider2D>();
            _damageCollider.gameObject.SetActive(true);
            _damageCollider.isTrigger = true;
            _damageCollider.enabled = false;
        }
        
        public void EnableDamageCollider()
        {
            _damageCollider.enabled = true;
            _damageCollider.isTrigger = true;
            _isSword = true;
        }
        public void DisableDamageCollider()
        {
            _damageCollider.enabled = false;
            _isSword = false;
        }

        public void EnableDefenseCollider()
        {
            _damageCollider.enabled = true;
            _damageCollider.isTrigger = false;
        }
        public void DisableDefenseCollider()
        {
            _damageCollider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (_isSword == false){return;}
            if (collider.CompareTag(TagManager.Player))
            {
                PlayerStats playerStats = collider.GetComponent<PlayerStats>();
         
                if (playerStats != null)
                { 
                    //       playerStats.TakeDamage(currentWeaponDamage);
                }
            }

            
            if (collider.CompareTag(TagManager.Enemy))
            {
                EnemyStats enemyStats = collider.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage,transform.parent.gameObject);
                }
            }
        }
    }
}