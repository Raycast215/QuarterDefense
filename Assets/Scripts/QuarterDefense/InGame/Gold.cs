using UnityEngine;

namespace QuarterDefense.InGame
{
    // Scripted by Raycast
    // 2023. 06. 13
    // InGame에서 사용되는 Gold를 관리하는 클래스입니다.
    
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