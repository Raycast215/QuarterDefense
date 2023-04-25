using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Background
{
    // Scripted by Raycast
    // 2023.04.26
    // 인게임 배경 연출용 반짝이 생성 클래스입니다.
    
    public class SparkCreator : MonoBehaviour
    {
        [SerializeField] private int targetCount = 100;
        [SerializeField] private Spark sparkPrefab = null;

        private void Start()
        {
            CreateSpark();
        }

        private void CreateSpark()
        {
            for (int i = 0; i < targetCount; i++)
            {
                Instantiate(sparkPrefab, transform);
            }
        }
    }
}