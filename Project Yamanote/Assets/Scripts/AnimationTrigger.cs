using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator targetAnimator;
    [SerializeField] private string animatorParimeter;
    [SerializeField] private bool animatorBool;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        targetAnimator.SetBool(animatorParimeter, animatorBool);
    }
}
