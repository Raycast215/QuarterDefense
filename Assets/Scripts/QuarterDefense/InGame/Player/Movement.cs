using System.Collections;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public class Movement : MonoBehaviour
    {
        // [SerializeField] private float speed = 10.0f;
        [SerializeField] private SpriteRenderer spriteRenderer = null;

        // public void MoveToTargetPos()
        // {
        //     StartCoroutine(OnMove());
        // }

        public void SetDirection(Vector3 targetPos)
        {
            float distance = transform.position.x - targetPos.x;
            
            spriteRenderer.flipX = distance > 0;
        }

        // private IEnumerator OnMove()
        // {
        //     Vector3 targetPos = GetRandomPos();
        //     
        //     while (Vector3.Distance(targetPos, transform.position) >= 0.1f)
        //     {
        //         transform.position = 
        //             Vector3.MoveTowards(transform.position, GetRandomPos(), speed * Time.deltaTime);
        //
        //         yield return null;
        //     }
        // }

        private Vector3 GetRandomPos()
        {
            float randomX = Random.Range(2.0f, 3.0f);
            float randomY = Random.Range(1.0f, 2.0f);
            
            return new Vector3(randomX, randomY, 0.0f);
        }
    }
}


