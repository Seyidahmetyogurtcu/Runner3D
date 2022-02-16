using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner3D.Core
{
    public class EventManager : MonoBehaviour
    {
        public delegate void TriggerEnter();
        public static event TriggerEnter OnObstacleTriggerEnter;

        public static void ObstacleTriggerEnter()
        {
            OnObstacleTriggerEnter?.Invoke();
        }
    }
}