using System;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.Upgrade
{
    public abstract class BaseUpgrade : MonoBehaviour
    {
        public Func<int> OnGoldAmountChecked = null; 
        public Action<int> OnGoldChanged = delegate {  };
        
        [SerializeField] protected int startCost;
        [SerializeField] private Text costText;
        protected int Cost { get; set; }
        
        private void Start() => Init();

        public virtual void TryUpgrade()
        {
            if(OnGoldAmountChecked() < Cost) return;
            
            OnGoldChanged.Invoke(Cost);

            Upgrade();
        }
        
        protected virtual void Init()
        {
            Cost = startCost;
            
            SetCostText(Cost);
        }

        protected abstract void Upgrade();
        
        protected void SetCostText(int cost) => costText.text = $"{cost}";
    }
}