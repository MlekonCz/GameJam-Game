using UnityEngine;

namespace Enemy
{
    public enum DeathAbilities
    {
        DoubleJump,
        WallWalk,
        SpeedBoost,
        BiggerStrength
    }
    
    [CreateAssetMenu(fileName = "Enemy", menuName = "Enemy", order = 0)]
    public class EnemyDefinition : ScriptableObject
    {
        [SerializeField] public int health;
        [SerializeField] public float jumpForce;
        [SerializeField] public float speed;
        [SerializeField] public float selfKnockBack;
        
        [SerializeField] public DeathAbilities deathAbility;
    }
}