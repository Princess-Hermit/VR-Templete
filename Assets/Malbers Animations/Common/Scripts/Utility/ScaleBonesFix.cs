﻿using UnityEngine;
using System.Collections;


namespace MalbersAnimations
{
    /// <summary>
    /// This class is used when the foot bones are scaled and when seat or lie or death do not match with the original animations
    /// it uses messages from the Animators Behaviors States.
    /// </summary>
    public class ScaleBonesFix : MonoBehaviour
    {
        [HelpBox("This is used to correct Seat/Death/Sleep Animations when the Legs are Scaled")]
        public Transform fixGameObject;
        public Vector3 Offset;
        public float duration;

        public void FixHeight(bool active)
        {
            StartCoroutine(SmoothFix(active));
        }

        public IEnumerator SmoothFix(bool active)
        {
            float t = 0f;
            Vector3 startpos = fixGameObject.localPosition;
            Vector3 endpos = startpos + (active ? Offset : -Offset);
            while (t < duration)
            {
                fixGameObject.localPosition = Vector3.Lerp(startpos, endpos, t / duration);
                t += Time.deltaTime;
                yield return null;
            }
        }
    }
}