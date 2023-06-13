using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.Upgrade
{
    public abstract class BaseUpgrade : MonoBehaviour
    {
        [SerializeField] private Gold gold;
        [SerializeField] protected int startCost;
        [SerializeField] private Text costText;
        public int Cost { get; set; }
        
        private void Start() => Init();

        public virtual void OnUpgrade()
        {
            if(gold.Amount < Cost) return;

            gold.Amount = -Cost;

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