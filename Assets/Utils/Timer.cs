using UnityEngine;
using System.Collections;
using System;

namespace Utils
{
    public class Timer : MonoBehaviour
    {
        public event Action onTick = null;

        public void Reset(float interval, bool is_looping)
        {
            Stop();
            StartCoroutine(Tick(interval, is_looping));
        }

        public void Stop()
        {
            onTick = null;
            StopAllCoroutines();
        }

        private IEnumerator Tick(float interval, bool is_looping)
        {
            do
            {
                yield return new WaitForSeconds(interval);

                onTick.Call();
            } while (is_looping);
        }
    }
}