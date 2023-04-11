using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.GoldSystem
{
    // Scripted by Raycast
    // 2023. 03. 14
    // 가중치 랜덤 Test
    
    public class Test : MonoBehaviour
    {
       // 해당 클래스는 Test를 수행하는 Main 클래스입니다.

       private Dictionary<string, int> testRandomItemList = null;

       private void Start()
       {
           Init();

           GetTotalWeight();
       }

       private void Init()
       {
           testRandomItemList = new Dictionary<string, int>()
           {
               {"Test001", 10},
               {"Test002", 100},
               {"Test003", 300},
               {"Test004", 700},
               {"Test005", 1000},
           };
       }

       private int GetTotalWeight()
       {
           int ret = 0;

           foreach (int weight in testRandomItemList.Values)
           {
               ret += weight;
           }
           
           Debug.Log(ret);

           return ret;
       }
    }
}