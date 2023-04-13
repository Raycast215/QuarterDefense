using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class TileStartEffect : MonoBehaviour
    {
        private const string StartClip = "Tile Start Effect";
        private const float DelayTime = 0.005f;
        
        public void PlayStartEffect(List<Tile> toList)
        {
            StartCoroutine(StartDelay(toList));
        }

        private IEnumerator StartDelay(List<Tile> toList)
        {
            yield return new WaitForSeconds(DelayTime);
            
            foreach (var tile in toList)
            {
                yield return new WaitForSeconds(DelayTime);
                
                tile.gameObject.SetActive(true);
                tile.TileAnimator.Play(StartClip, 0, 0.0f);
            }
        }
    }
}