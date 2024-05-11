using System.Collections;
using UnityEngine;

namespace Cloth.HUD
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup _canvas;
        [SerializeField] protected float _fadeDuration;

        public virtual void OpenWindow()
        {
            _canvas.alpha = 0;
            gameObject.SetActive(true);
            StartCoroutine(FadeWindow(0, 1));
        }

        public virtual void CloseWindow()
        {
            StartCoroutine(FadeWindow(1, 0));
            Invoke("OnWindowClosed", _fadeDuration);
        }

        protected virtual void OnWindowClosed()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator FadeWindow(float from, float to)
        {
            float alpha;
            float time = 0;

            while (time < 1)
            {
                alpha = Mathf.Lerp(from, to, time);
                _canvas.alpha = alpha;

                time += Time.fixedDeltaTime / _fadeDuration;
                yield return new WaitForFixedUpdate();
            }
        }
    }
}