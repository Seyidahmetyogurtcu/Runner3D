using Runner3D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner3D.Game
{
    public class StickmanController : MonoBehaviour
    {
        public GameObject nLevelButton;
        public List<GameObject> confettiSprays;
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
            transform.position += new Vector3(0,0,1) *Time.deltaTime* GameManager.StickmanForwardSpeed;
        }

        void Update()
        {
            if (GameManager.playerState==State.Run|| GameManager.playerState == State.Jump)
            {
                EventManager.ObstacleTriggerEnter();
                
                transform.position=new Vector3(StickmanInput.GetHorizontalInput(), transform.position.y,transform.position.z);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                GameManager.playerState = State.Jump; 
            }
            if (other.CompareTag("Finish"))
            {
                GameManager.playerState = State.Finish;
                nLevelButton.SetActive(true);
                foreach (GameObject c in confettiSprays)
                {
                    c.SetActive(true);
                    c.GetComponent<ParticleSystem>().Play();
                }
            }
            if (other.CompareTag("Collectable"))
            {
                other.gameObject.SetActive(false);
                ScoreManager.ScoreUp();
                UIManager.instance.UpdateScore();
            }
        }
    }
}
