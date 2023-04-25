using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private Transform trans = null;
        
        public void SetRotate(float angle)
        {
            if (!trans)
            {
                Debug.Log("Null Transform Component...");
                return;
            }
            
            trans.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}