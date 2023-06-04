using UnityEngine;

namespace QuarterDefense.InGame.UI.Viewer
{
    // Scripted by Raycast
    // 2023. 05. 09
    // UI에 표시할 Viewer의 상위 클래스입니다.
    
    public abstract class Viewer : MonoBehaviour
    {
        public abstract void Set(int value = 0);
    }
}