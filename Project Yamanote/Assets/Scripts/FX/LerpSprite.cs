using ProjectYamanote.Persistence;
using System;
using System.Collections;
using UnityEngine;

namespace ProjectYamanote.FX
{
    public class LerpSprite : MonoBehaviour
    {
        public AnimationCurve animationCurve;
        public Vector3 lerpOffset;
        public Transform startPosition;
        public Transform endPosition;

        private SpriteRenderer _sprite;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            float t = Mathf.InverseLerp(0.0f, 1440.0f, (float)GameClock.dateTime.TimeOfDay.TotalMinutes);
            
            Vector3 positionOffset = animationCurve.Evaluate(t) * lerpOffset;
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t) + positionOffset;
        }
    }
}
