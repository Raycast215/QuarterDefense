using UnityEngine;

namespace QuarterDefense.InGame
{
    public delegate void GoldChangeDelegate(int toGold);
    
    public class Gold : MonoBehaviour
    {
        public event GoldChangeDelegate OnGoldViewerChanged = delegate {  };

        private int _gold;
        
        public int Amount
        {
            get => _gold;
            set
            {
                _gold += value;
                OnGoldViewerChanged.Invoke(_gold);
            }
        }
    }
}