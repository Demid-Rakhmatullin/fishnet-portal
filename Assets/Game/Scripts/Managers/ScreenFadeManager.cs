using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Managers
{
    class ScreenFadeManager : MonoSingleton<ScreenFadeManager>
    {
        [SerializeField] Image fadeImage;
        [SerializeField] float fadeInTime = 1.5f;
        [SerializeField] bool fadeOutOnStart;

        private RectTransform _rectTransform;
        private float _startFadeInTime;

        void Awake()
        {
            _rectTransform = fadeImage.GetComponent<RectTransform>();
        }

        void Start()
        {
            if (fadeOutOnStart)
            {
                SetAlpha(1f);
                fadeImage.gameObject.SetActive(true);
                FadeOut(0.7f);
            }
            else
            {
                fadeImage.gameObject.SetActive(false);
            }
        }

        public void StartFadeIn(Action onComplete = null)
        {
            if (_startFadeInTime > 0f)
            {
                onComplete?.Invoke();
                return;
            }

            SetAlpha(0f);
            fadeImage.gameObject.SetActive(true);

            LeanTween.alpha(_rectTransform, 1f, fadeInTime)
                .setOnComplete(() => _startFadeInTime = 0f)
                .setOnComplete(() =>
                {
                    _startFadeInTime = 0f;
                    onComplete?.Invoke();
                });

            _startFadeInTime = Time.time;
        }

        public void CancelFadeIn()
        {
            if (_startFadeInTime > 0f)
            {
                LeanTween.cancel(_rectTransform);
                FadeOut(Time.time - _startFadeInTime)
                    .setOnComplete(() => _startFadeInTime = 0f);
            }
        }

        private LTDescr FadeOut(float time)
        {
            return LeanTween.alpha(_rectTransform, 0f, time)
                .setEaseOutQuad()
                .setOnComplete(() => fadeImage.gameObject.SetActive(false));
        }

        private void SetAlpha(float alpha)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, 
                fadeImage.color.b, alpha);
        }
    }
}
