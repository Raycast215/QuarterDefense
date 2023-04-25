using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame
{
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