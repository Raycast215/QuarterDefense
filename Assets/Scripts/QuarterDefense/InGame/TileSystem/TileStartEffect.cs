using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using QuarterDefense.Common;

namespace QuarterDefense.InGame.TileSystem
{
    // Scripted by Raycast
    // 2023.04.19
    // Tile이 등장하는 연출 클래스.
    
    public class TileStartEffect : MonoBehaviour
    {
        private const string StartClip = "Tile Start Effect";
        private const float StartDelayTime = 1.0f;
        private const float TileDelayTime = 0.005f;

        private bool _isStart = false;
        
        private List<int> _randomIndexList = new List<int>();

        public void SetTileList(List<Tile> toList)
        {
            SetRandomIndexList();
            StartCoroutine(StartTileEffect(toList));
        }
        
        private void SetRandomIndexList()
        {
            _randomIndexList = new List<int>();
            
            for (int i = 0; i < Constants.MaxTileCount; i++)
            {
                _randomIndexList.Add(i);
            }

            _isStart = true;
        }

        private IEnumerator StartTileEffect(List<Tile> toList)
        {
            // 시작 준비가 완료될 때까지 대기 후 Tile 등장 연출 재생.
            yield return new WaitForSeconds(StartDelayTime);
            yield return new WaitUntil(() => _isStart);
            
            while (true)
            {
                if (_randomIndexList.Count <= 0) yield break;
                
                int randomIndex = Random.Range(0, _randomIndexList.Count);
                
                TileEffect(toList[_randomIndexList[randomIndex]]);
                    
                _randomIndexList.RemoveAt(randomIndex);
                    
                yield return new WaitForSeconds(TileDelayTime);
            }
        }
        
        private void TileEffect(Tile toTile)
        {
            toTile.gameObject.SetActive(true);
            toTile.TileAnimator.Play(StartClip, 0, 0.0f);
        }
    }
}