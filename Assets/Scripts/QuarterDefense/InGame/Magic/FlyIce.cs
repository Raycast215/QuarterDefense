using System;
using System.Collections;
using UnityEngine;

namespace QuarterDefense.InGame.Magic
{
    // Scripted by Raycast
    // 2023. 06. 15
    // Ice Effect 용 클래스입니다.
    
    public class FlyIce : MonoBehaviour
    {
        private const string Clip = "Fly";
        private const string Revers = "Fly Revers";
        
        [SerializeField] private Animator[] animators;

        private Coroutine _effectRoutine;
        
        private void OnEnable()
        {
            if(_effectRoutine != null) StopCoroutine(_effectRoutine);
            _effectRoutine = StartCoroutine(OnPlayEffect());
        }

        private IEnumerator OnPlayEffect()
        {
            animators[0].Play(Clip, 0, 0.0f);
            
            yield return new WaitForSeconds(0.1f);

            animators[1].Play(Revers, 0, 0.0f);
            
            yield return new WaitForSeconds(0.1f);
            
            animators[2].Play(Clip, 0, 0.0f);
        }
    }
}