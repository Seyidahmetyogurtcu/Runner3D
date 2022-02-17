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
        Animator stickmanAnimator;
        void Start()
        {
            EventManager.OnObstacleTriggerEnter += MoveForward;
            stickmanAnimator = GetComponent<Animator>();
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
                stickmanAnimator.SetBool("Run", true);
            }
            if (GameManager.playerState == State.Finish)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 1*Time.deltaTime);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                GameManager.playerState = State.Jump;
                stickmanAnimator.SetTrigger("Jump");

            }
            if (other.CompareTag("Finish"))
            {
                GameManager.playerState = State.Finish;
                stickmanAnimator.SetBool("Finish", true);

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
