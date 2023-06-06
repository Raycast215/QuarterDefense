using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI.Viewer
{
    // Scripted by Raycast
    // 2023. 05. 09
    // Gold를 UI에 표시하는 클래스입니다.
    
    public class GoldViewer : MonoBehaviour
    {
        [SerializeField] private Text goldText;
        
        public void SetText(int toGold)
        {
            goldText.text = $"{toGold}";
        }
    }
}