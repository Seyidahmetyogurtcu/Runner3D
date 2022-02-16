using Runner3D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner3D.Game
{
    public class UIManager : MonoBehaviour
    {
        public GameObject startPanel;
        public void StartButton()
        {
            startPanel.SetActive(false);
            GameManager.playerState = State.Run;
        }
    }
}
