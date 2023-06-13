using System;
using System.Collections;
using System.Collections.Generic;
using QuarterDefense.InGame.Character;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace QuarterDefense.InGame.Player
{
    public class Character : MonoBehaviour
    {
        public event Action <Character> OnDied = delegate {  };

        [SerializeField] protected Movement movement;
        [SerializeField] private AnimationPlayer aniPlayer;
        [SerializeField] private SpriteRotate spriteRotate;
        [SerializeField] private SpriteLibrary spriteLibrary;
        
        public CharacterType CharacterType { get; set; }
        public CharacterRank CharacterRank { get; set; }
        public SpriteLibraryAsset CharacterSprite { set => spriteLibrary.spriteLibraryAsset = value; }
        
        private void Start()
        {
            movement.OnDirectionChanged += spriteRotate.SetDirection;
            movement.OnMoveFinished += () => aniPlayer.OnPlayAnimation(CharacterAniState.Idle);
        }

        private void OnEnable()
        {
            transform.position = Vector3.zero;
        }

        private void OnDisable()
        {
            OnDied.Invoke(this);
        }
    }
}