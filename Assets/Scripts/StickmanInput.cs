using Runner3D.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner3D.Game
{
    public class StickmanInput : MonoBehaviour
    {
        const float NormalizeSpeedForPc = 0.003f;
        const float NormalizeSpeedForMobile = 0.005f;

        static private Vector3 initialPosition;
        static private Vector3 finalPosition;
        static private Vector3 horizontalMoveVector;
        static Vector3 clampedPos = new Vector3(0,0, 0);

        public static void ResetHorizontalInput()
        {
            clampedPos.x = 0;
        }
        public static float GetHorizontalInput()
        {
#if UNITY_ANDROID && !UNITY_EDITOR_64
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase ==TouchPhase.Began)
            {
                initialPosition = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                finalPosition = touch.position;
                
                horizontalMoveVector = initialPosition- finalPosition;
                Vector3 temp2=Vector3.zero;
                temp2.x = -horizontalMoveVector.x;// screen UI use x(horizontal)-y(vertical) coordinate oposite

                clampedPos += (temp2 * Time.deltaTime* GameManager.instance.playerSpeedHorizontal);
                clampedPos.x = Mathf.Clamp(clampedPos.x, -2.22f, +2.22f);

            }
            return clampedPos.x;
        }
#endif

#if UNITY_EDITOR_64
            if (Input.GetMouseButtonDown(0))
            {
                initialPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                finalPosition = Input.mousePosition;

                horizontalMoveVector = initialPosition - finalPosition;
                Vector3 temp2 = Vector3.zero;
                temp2.x = -horizontalMoveVector.x; //  screen UI use x(horizontal)-y(vertical) coordinate oposite

                clampedPos += (temp2 * Time.deltaTime * GameManager.StickmanVecticalSpeed);
                clampedPos.x = Mathf.Clamp(clampedPos.x, -2.22f, +2.22f);
            }
            else
            {
                horizontalMoveVector = Vector3.zero;
            }
            return clampedPos.x;
#endif
        }
    }
}


