using UnityEngine;

namespace ProjectYamanote.Triggers
{
    public class AnimationTrigger : MonoBehaviour
    {
        [SerializeField] private Animator _targetAnimator;
        [SerializeField] private string _animatorParimeter;
        [SerializeField] private bool _animatorBool;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _targetAnimator.SetBool(_animatorParimeter, _animatorBool);
        }
    }
}