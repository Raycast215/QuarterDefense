using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI.Viewer
{
    // Scripted by Raycast
    // 2023. 05. 09
    // Gold를 UI에 표시하는 클래스입니다.
    
    public class GoldViewer : Viewer
    {
        [SerializeField] private Text goldText;

        public int Gold { get; private set; } = 0;
        
        public override void Set(int value = 0)
        {
            Gold += value;

            goldText.text = $"{Gold}";
        }
    }
}