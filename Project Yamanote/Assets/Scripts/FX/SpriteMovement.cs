using ProjectYamanote.Persistence;
using System.Collections;
using UnityEngine;

namespace EasyParallax
{
    /**
 * Moves a sprite along the X axes using a predefined speed
 */

    public class SpriteMovement : MonoBehaviour
    {
        public MovementSpeedType movementSpeedType;
        private SpriteRenderer spriteRenderer;

        [Tooltip("Used only if no movement speed type is specified")]
        public float speed = 1f;

        private void Awake()
        {
            if (movementSpeedType)
                speed = movementSpeedType.speed;

            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            var newPosition = transform.position;
            newPosition.x -= speed * Time.deltaTime;
            transform.position = newPosition;

            float t = Mathf.InverseLerp(0.0f, 1440.0f, (float)GameClock.dateTime.TimeOfDay.TotalMinutes);

            transform.position = Vector3.Lerp(transform.position, newPosition, t);
        }

        public IEnumerator SpeedDownParallax()
        {
            while (speed > 0)
            {
                speed -= 0.3f * Time.deltaTime;
                yield return null;
            }
        }

        public IEnumerator SpeedUpParallax()
        {
            yield return new WaitForSeconds(5);

            switch (spriteRenderer.sortingLayerName)
            {
                case "Background 3":
                    while (speed < 5)
                    {
                        speed += 0.3f * Time.deltaTime;
                        yield return null;
                    }
                    break;

                case "Background 4":
                    while (speed < 5)
                    {
                        speed += 0.3f * Time.deltaTime;
                        yield return null;
                    }
                    break;

                case "Background 5":
                    while (speed < 4.5)
                    {
                        speed += 0.3f * Time.deltaTime;
                        yield return null;
                    }
                    break;

                case "Background 6":
                    while (speed < 3.5)
                    {
                        speed += 0.3f * Time.deltaTime;
                        yield return null;
                    }
                    break;

                case "Background 7":
                    while (speed < 2)
                    {
                        speed += 0.3f * Time.deltaTime;
                        yield return null;
                    }
                    break;

                case "Background 8":
                    while (speed < 1.5)
                    {
                        speed += 0.3f * Time.deltaTime;
                        yield return null;
                    }
                    break;
            }
        }

        public void Stop()
        {
            speed = 0;
        }
    }
}