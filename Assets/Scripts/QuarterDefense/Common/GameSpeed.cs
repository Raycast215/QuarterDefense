using UnityEngine;

namespace QuarterDefense.Common
{
    // Scripted by Raycast
    // 2023. 05. 08
    // Game 배속 조절 클래스.
    
    public class GameSpeed : MonoBehaviour
    {
        [SerializeField] private int gameSpeed = 1;
        [SerializeField] private GameObject[] speedIcons = null;

        private void Start()
        {
            SetIcon();
        }
        
        public void SetSpeed()
        { 
            Util.ClampCount(ref gameSpeed, 1, 1, speedIcons.Length);

            SetIcon();

            Time.timeScale = gameSpeed;
           
            // Debug.Log($"Game Speed : {gameSpeed}");
        }
        
        private void SetIcon()
        {
            for (int i = 0; i < speedIcons.Length; i++)
            {
                bool isActivate = gameSpeed - 1 == i;
                
                speedIcons[i].SetActive(isActivate);
            }
        }
    }
}