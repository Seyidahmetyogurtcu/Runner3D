using Runner3D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner3D.Game
{
    public class StickmanController : MonoBehaviour
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
            transform.position += new Vector3(0,0,1) *Time.deltaTime* GameManager.StickmanSpeed;
        }

        void Update()
        {
            if (GameManager.playerState==State.Run|| GameManager.playerState == State.Jump)
            {
                EventManager.ObstacleTriggerEnter();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                GameManager.playerState = State.Jump;
                //Do Jump animation.
                
            }
        }
    }
}
