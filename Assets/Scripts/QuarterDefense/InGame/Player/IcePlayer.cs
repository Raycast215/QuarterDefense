using System;
using QuarterDefense.InGame.Character.Enemy;
using QuarterDefense.InGame.Magic;

namespace QuarterDefense.InGame.Player
{
    public class IcePlayer : Player
    {
        protected override void OnAttack(Enemy enemy)
        {
            IceBolt iceBolt = Instantiate(magicPrefab, transform)?.GetComponent<IceBolt>();
            
            if (iceBolt != null)
            {
                iceBolt.SetEnemy(enemy);
                iceBolt.SetPos(transform.position);
            }
        }
    }
}