using System;
using Core;
using Player;
using UnityEngine;

namespace Enemy
{
    public class CollisionDamager : MonoBehaviour
    {
        [SerializeField] private float knockPower = 20f;
        [SerializeField] private float knockDuration = 0.4f;
        private Vector2 _pushDirection;
        private DeathAbilities _deathAbilities;

        private void Start()
        {
            if (GetComponent<EnemyStats>())
            {
                _deathAbilities = GetComponent<EnemyStats>().enemyDefinition.deathAbility;
            }
           
            if (_deathAbilities == null)
            {
                _deathAbilities = DeathAbilities.Empty;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject player = other.gameObject;
            if (player.CompareTag(TagManager.Player))
            {
                player.GetComponent<PlayerStats>().TakeDamage(1, _deathAbilities);

               _pushDirection = (player.transform.position - transform.position);
                _pushDirection.Normalize();

                KnockBack(_pushDirection, player);
            
            }
        }
    
        private void KnockBack(Vector2 knockBackDirection,GameObject player)
        {
            Debug.Log("Hazard direction: " + knockBackDirection);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockBackDirection.x * knockPower / 2,knockBackDirection.y * knockPower));
        }
    }
}
