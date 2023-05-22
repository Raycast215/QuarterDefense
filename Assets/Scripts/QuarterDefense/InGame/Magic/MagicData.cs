using UnityEngine;

namespace QuarterDefense.InGame.Magic
{
    [CreateAssetMenu(fileName = "Magic Data", menuName = "Scriptable Object/Magic Data", order = int.MaxValue)]
    public class MagicData : ScriptableObject
    {
        [SerializeField] private float damage;
        [SerializeField] private float speed;
        [SerializeField] private float damageRiseValue;
        
        public float Damage => damage;
        public float Speed => speed;
        public float DamageRiseValue => damageRiseValue;
    }
}