using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 27
    // Character 애니메이션 재생 클래스.
    
    public enum CharacterAniState { Idle, Walk, Attack }
    
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void Start()
        {
            OnPlayAnimation(CharacterAniState.Walk);
        }

        public void OnPlayAnimation(CharacterAniState aniState)
        {
            animator.Play($"Player_{aniState}", 0, 0.0f);
        }
    }
}


