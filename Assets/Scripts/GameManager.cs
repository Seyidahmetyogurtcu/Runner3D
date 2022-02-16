using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner3D.Core
{
    public class GameManager : MonoBehaviour
    {   
        public static GameManager instance;
      
        public static State playerState;

        public const int StickmanForwardSpeed = 5;
        public const float StickmanVecticalSpeed = 0.03f;

        private void Awake()
        {
            if (instance=null)
            {
                instance = this;
            }
            else if (instance!=this)
            {
                Destroy(this);
            }
            DontDestroyOnLoad(gameObject);

        }

        private void Start()
        {
            playerState = State.Idle;
        }
        void Update()
        {
            switch (playerState)
            {
                case State.Idle:
                    //do
                    break;
                case State.Run:
                    //do
                    break;
                case State.Jump:
                    //do
                    break;
                case State.Finish:
                    //doAnimation
                    //set position
                    break;
            }
        }
    }

}