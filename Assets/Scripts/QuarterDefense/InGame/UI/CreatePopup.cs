using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    public class CreatePopup : MonoBehaviour
    {
        private const float CloseDelay = 2.0f;
        
        [SerializeField] private Animator animator;
        [SerializeField] private Text getText;

        private Coroutine _closeRoutine;

        private int BgLayer => animator.GetLayerIndex("BG Layer");
        private int TextLayer => animator.GetLayerIndex("Text Layer");
        
        public void ShowPopup(CharacterData data)
        {
            gameObject.SetActive(true);
            
           // getText.text = $"[{data.rank.ToString().ToUpper()}] {data.characterName} 소환!";

            if (!gameObject.activeInHierarchy) animator.Play("Show", BgLayer, 0.0f);
            animator.Play("Get", TextLayer, 0.0f);
            
            if(_closeRoutine != null) StopCoroutine(_closeRoutine);
            _closeRoutine = StartCoroutine(OnClose());
        }

        private IEnumerator OnClose()
        {
            yield return new WaitForSeconds(CloseDelay);
            
            animator.Play("Close", BgLayer, 0.0f);
            
            gameObject.SetActive(false);
        }
    }
}