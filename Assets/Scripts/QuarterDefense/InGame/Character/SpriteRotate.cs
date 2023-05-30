using UnityEngine;

namespace QuarterDefense.InGame.Character
{
    // Scripted by Raycast
    // 2023. 05. 27
    // 타겟의 위치에 따라 Sprite의 방향을 바뀌주기 위한 클래스.
    
    public class SpriteRotate : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public void SetDirection(Vector3 targetPos)
        {
            float distance = transform.position.x - targetPos.x;
            
            spriteRenderer.flipX = distance > 0;
        } 
    }
}