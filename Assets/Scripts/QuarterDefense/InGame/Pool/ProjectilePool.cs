using QuarterDefense.InGame.Character.Enemy;
using QuarterDefense.InGame.Magic;
using UnityEngine;

namespace QuarterDefense.InGame.Pool
{
    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private IceBolt magicPrefab;
        [SerializeField] private int capacity;
        [SerializeField] private Transform poolLayer;
        
        private Pooling<IceBolt> _projectilePool;
        
        private void Awake()
        {
            _projectilePool = new Pooling<IceBolt>(magicPrefab, capacity, poolLayer);
            _projectilePool.Pool();
        }

        public void GetProjectile(Player.Character.CharacterRank rank, Vector3 pos, Enemy enemy)
        {
            IceBolt iceBolt = _projectilePool.Get();
            
            iceBolt.SetScale(rank);
            iceBolt.SetPos(pos);
            iceBolt.SetEnemy(enemy);
        }
    }
}