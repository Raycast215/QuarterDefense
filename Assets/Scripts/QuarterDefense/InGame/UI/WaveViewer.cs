using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    // Scripted by Raycast
    // 2023. 05. 09
    // Wave를 UI에 표시하는 클래스입니다.
    
    public class WaveViewer : Viewer
    {
        [SerializeField] private Text waveText = null;

        public int Wave { get; private set; } = 0;

        public override void Set(int delta)
        {
            Wave += delta;
            
            waveText.text = $"Wave {Wave}";
        }
    }
}