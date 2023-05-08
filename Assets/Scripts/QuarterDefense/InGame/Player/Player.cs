using System;
using System.Collections;
using System.Collections.Generic;
using QuarterDefense.InGame.Bullet;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private BulletController bulletController = null;
       
        private void Start()
        {
            //StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            
            
            yield return new WaitForSeconds(3.0f);
            
            while (true)
            {
                yield return new WaitForSeconds(1.0f);

                BaseBullet bullet = bulletController.FindUsableBullet();

                if (!bullet) continue;
                
                bullet.Spawned();
            }
        }
    }
}

