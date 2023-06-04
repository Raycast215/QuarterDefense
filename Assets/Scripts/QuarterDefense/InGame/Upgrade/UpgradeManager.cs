using System;
using UnityEngine;

namespace QuarterDefense.InGame.Upgrade
{
    public class UpgradeManager : MonoBehaviour
    {
        public Func<int> OnGoldAmountChecked = null; 
        public Action<int> OnGoldChanged = delegate {  };
        
        [SerializeField] private BaseUpgrade[] upgrades;

        public void Init()
        {
            foreach (var upgrade in upgrades)
            {
                upgrade.OnGoldAmountChecked += OnGoldAmountChecked;
                upgrade.OnGoldChanged += OnGoldChanged;
            }
        }
    }
}