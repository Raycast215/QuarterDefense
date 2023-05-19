using UnityEngine;

namespace QuarterDefense.InGame
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPoints = null;
        public Transform[] GetWayPoints => wayPoints;
    }
}