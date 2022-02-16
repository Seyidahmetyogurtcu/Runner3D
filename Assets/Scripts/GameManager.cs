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

        public const int StickmanSpeed = 10;

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
                    //do
                    break;
            }
        }
    }

}