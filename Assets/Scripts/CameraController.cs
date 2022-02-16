using Runner3D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner3D.Game
{
    public class CameraController : MonoBehaviour
    {
        void Start()
        {
            EventManager.OnObstacleTriggerEnter += MoveForward;
        }
        private void OnDestroy()
        {
            EventManager.OnObstacleTriggerEnter -= MoveForward;

        }

        private void MoveForward()
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * GameManager.StickmanSpeed;
        }
        void Update()
        {

        }
    }
}