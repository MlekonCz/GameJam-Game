using UnityEngine;

namespace Enemy
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] public EnemyDefinition enemyDefinition;

        private int _health;
        private float _knockBackForce;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _health = enemyDefinition.health;
            _knockBackForce = enemyDefinition.selfKnockBack;
        }

        public void TakeDamage(int damage, GameObject player)
        {
             _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                var direction = ( transform.position - player.transform.position );
                direction.Normalize();
                Debug.Log(direction);
                KnockBack(direction);
            }
        }

        private void KnockBack( Vector2 knockBackDirection)
        {
            Debug.Log("Enemy direction: " + knockBackDirection);
            _rigidbody2D.AddForce(new Vector2(knockBackDirection.x, -knockBackDirection.y * _knockBackForce *2));
        }


    }
}
