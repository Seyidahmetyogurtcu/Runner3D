using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner3D.Game
{
    public class LevelManager : MonoBehaviour
    {
        public GameObject obstacle;
        public GameObject collectable;
        int totalMapLength = 110;
        int objectGap = 10;
        const float ObstacleHeight = 0.25f;
        const float CollectableHeight = 1.5f;
        void Start()
        {
            DoRandomInstantiate(obstacle, collectable);
        }
        void DoRandomInstantiate(params GameObject[] objects)
        {
            for (int j = 10; j < totalMapLength; j += objectGap)
            {
                int rand = UnityEngine.Random.Range(0, 3);
                if (rand != 0)
                {
                    Instantiate(objects[0], new Vector3(0, ObstacleHeight, j), Quaternion.identity);
                }
                if (rand != 1)
                {
                    Instantiate(objects[1], new Vector3(UnityEngine.Random.Range(-2, 2), CollectableHeight, j), Quaternion.identity);
                }
            }
        }

        void Update()
        {

        }
    }
}
