using UnityEngine;

namespace QuarterDefense.InGame
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField] private Transform startPoint = null;
        [SerializeField] private Transform[] wayPoints = null;

        public Transform GetStartPoint => startPoint;
        public Transform[] GetWayPoints => wayPoints;
    }
}