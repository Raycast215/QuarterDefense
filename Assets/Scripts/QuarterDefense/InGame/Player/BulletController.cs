using System.Collections.Generic;
using System.Linq;
using QuarterDefense.InGame.Bullet;
using QuarterDefense.InGame.Interface;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public class BulletController : MonoBehaviour, IAttackable
    {
        [SerializeField] private int maxCount = 32;
        [SerializeField] private BaseBullet bulletPrefab = null;
        [SerializeField] private Transform bulletLayer = null;
        
        private readonly List<BaseBullet> _bulletList = new List<BaseBullet>();

        private void Start()
        {
            CreateBullet();
        }

        public BaseBullet FindUsableBullet()
        {
            foreach (var bullet in _bulletList.Where(bullet => !bullet.gameObject.activeInHierarchy))
            {
                return bullet;
            }

            return FindUsableBullet();
        }
        
        private void CreateBullet()
        {
            for (int i = 0; i < maxCount; i++)
            {
                var instance = Instantiate(bulletPrefab, bulletLayer);
                instance.Despawned();
                
                _bulletList.Add(instance);
            }
        }

        public bool CheckAttackableState()
        {
            throw new System.NotImplementedException();
        }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}