using Runner3D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Runner3D.Game
{
    public class UIManager : MonoBehaviour
    {
        public GameObject startPanel;
        public TMP_Text scoreText;
        public static UIManager instance;
        private void Awake()
        {


                instance = this;
      

        }

        private void Start()
        {
            UpdateScore();
        }
        public void UpdateScore()
        {
            scoreText.text = ScoreManager.Score;
        }
        public void StartButton()
        {
            startPanel.SetActive(false);
            GameManager.playerState = State.Run;
        }
        public void NextLevelButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
