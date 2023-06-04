using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI.Viewer
{
    // Scripted by Raycast
    // 2023. 05. 20
    // 현재 생존한 Enemy의 수량을 UI에 표시하는 클래스입니다.
    
    public class EnemyCountViewer : Viewer
    {
        [SerializeField] private Text enemyCountText;
        [SerializeField] private Image gaugeBar;

        private int _enemyCount;
        private int _maxEnemyCount;

        public void SetMaxEnemyCount(int value) => _maxEnemyCount = value;
        
        public override void Set(int value = 0)
        {
            _enemyCount += value;
            
            enemyCountText.text = $"{_enemyCount} / {_maxEnemyCount}";

            SetGauge();
        }

        private void SetGauge()
        {
            float gauge = (float)_enemyCount / _maxEnemyCount;
            
            gaugeBar.fillAmount = gauge;
        }
    }
}