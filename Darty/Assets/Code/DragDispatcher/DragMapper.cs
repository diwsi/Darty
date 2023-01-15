using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.DragDispatcher
{
    internal static class DragMapper
    {
        public static bool IsDragStarted
        {
            get
            {

                if (Input.GetMouseButtonDown(0))
                {
                    return true;
                }


                if (IsTouch && touchPhase == TouchPhase.Began)
                {
                    return true;
                }
                return false;
            }
        }


        public static bool IsDragging
        {
            get
            {
                if (Input.GetMouseButton(0))
                {
                    return true;
                }

                if (IsTouch)
                {
                    return true;
                }
                return false;
            }
        }

        public static bool IsRelased
        {
            get
            {
                if (Input.GetMouseButtonUp(0))
                {
                    return true;
                }

                if (IsTouch && touchPhase==TouchPhase.Ended)
                {
                    return true;
                }
                return false;
            }
        }


        public static Vector2 DragPoint
        {
            get
            {

                if (IsTouch)
                {
                    return Input.touches[0].position;
                }

                return Input.mousePosition;

            }
        }



        private static bool IsTouch
        {
            get
            {
                return Input.touchCount > 0;
            }
        }

        private static TouchPhase? touchPhase
        {
            get
            {
                if (!IsTouch)
                {
                    return null;
                }
                return Input.touches[0].phase;
            }
        }

    }
}
