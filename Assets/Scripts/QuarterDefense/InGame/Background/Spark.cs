using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace QuarterDefense.InGame.Background
{
    // Scripted by Raycast
    // 2023.04.26
    // 인게임 배경 연출용 반짝이 클래스입니다.
    
    public class Spark : MonoBehaviour
    {
        private const float MaxWidth = 40.0f;
        private const float MaxHeight = 15.0f;
        private const float MinAnimationSpeed = 0.1f;
        
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private Transform targetTransform = null;
        [SerializeField] private Animator animator = null;
        [SerializeField] private float maxAnimationSpeed = 3.0f;

        private void Start()
        {
            SetPosition();
            SetColor();
            SetAnimationSpeed();
        }

        private void SetPosition()
        {
            float width = GetRandom(MaxWidth);
            float height = GetRandom(MaxHeight);
            
            targetTransform.position = new Vector3(width, height, 0.0f);
        }
        
        private float GetRandom(float targetNum)
        {
            float randomWidth = Random.Range(-targetNum, targetNum);

            return randomWidth;
        }

        private void SetAnimationSpeed()
        {
            float randomSpeed = Random.Range(MinAnimationSpeed, maxAnimationSpeed);

            animator.speed = randomSpeed;
        }

        private void SetColor()
        {
            float red = Random.Range(0.5f, 1.0f);
            float green = Random.Range(0.5f, 1.0f);
            float blue = Random.Range(0.5f, 1.0f);

            spriteRenderer.color = new Color(red, green, blue);
        }
    }
}