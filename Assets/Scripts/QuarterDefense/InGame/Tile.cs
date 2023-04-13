using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Animator animator = null;

        public Animator TileAnimator => animator;
    }
}