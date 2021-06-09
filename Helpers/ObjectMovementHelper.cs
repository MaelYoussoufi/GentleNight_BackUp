using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class ObjectMovementHelper
    {
        //TODO: move logic to move shit there
        // With a coroutine with a callback

        public static double MoveNegligibleDistance => 0.1;

        public static IEnumerable<Vector3> MovingMiniRoutine_Smooth(Vector3 start, Vector3 destination, float MovementTime = 1)
        {
            var currentPos = start;
            var currentVelocity = Vector3.zero;
            while (Vector3.Distance(currentPos, destination) > ObjectMovementHelper.MoveNegligibleDistance)
            {
                currentPos = Vector3.SmoothDamp(currentPos,
                    destination, ref currentVelocity, MovementTime);
                yield return currentPos;
            }
        }

        public static IEnumerable<Vector3> MovingMiniRoutine_Straight(Vector3 start, Vector3 destination, float MovementTime = 1)
        {
            var currentPos = start;
            var currentVelocity = Vector3.zero;
            while (Vector3.Distance(currentPos, destination) > ObjectMovementHelper.MoveNegligibleDistance)
            {
                currentPos = Vector3.MoveTowards(currentPos,
                    destination, Vector3.Distance(start, destination) * Time.deltaTime / MovementTime);
                yield return currentPos;
            }
        }

        //TODO: Add a trajectory modifier to the MiniRoutines
    }
}

