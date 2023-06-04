using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.Upgrade
{
    public class IceDamageUp : BaseUpgrade
    {
        private const int IncreaseDelta = 50;
        
        [SerializeField] private Text levelText;

        private int _level;

        public override void TryUpgrade()
        {
            if(OnGoldAmountChecked() < Cost) return;
            
            OnGoldChanged.Invoke(Cost);

            Upgrade();
        }
        
        protected override void Upgrade()
        {
            _level++;
            Cost += IncreaseDelta;

            SetLevelText(_level);
            SetCostText(Cost);
        }
        
        private void SetLevelText(int level) => levelText.text = $"LV.{level}";
    }
}