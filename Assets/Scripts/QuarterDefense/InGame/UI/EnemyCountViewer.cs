using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    // Scripted by Raycast
    // 2023. 05. 20
    // 현재 생존한 Enemy의 수량을 UI에 표시하는 클래스입니다.
    
    public class EnemyCountViewer : MonoBehaviour
    {
        [SerializeField] private Text enemyCountText = null;

        private void Start()
        {
            Set(0);
        }

        public void Set(int enemyCount)
        {
            enemyCountText.text = $"{enemyCount} / 256";
        }
    }
}