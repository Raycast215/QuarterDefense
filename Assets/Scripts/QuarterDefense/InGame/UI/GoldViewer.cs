using QuarterDefense.Common;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    // Scripted by Raycast
    // 2023. 05. 09
    // Gold를 UI에 표시하는 클래스입니다.
    
    public class GoldViewer : Viewer
    {
        [SerializeField] private Text goldText = null;
        [SerializeField] private Animator animator = null;
        
        private int _currentGold = 0;

        public override void Set(int delta)
        {
            _currentGold += delta;

            goldText.text = $"{_currentGold}";
            
            Util.SetTextRect(goldText);
            
            animator.Play("Change", 0, 0.0f);
        }
    }
}