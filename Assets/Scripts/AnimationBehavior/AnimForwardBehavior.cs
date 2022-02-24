using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimForwardBehavior : Jumps, IAnimationBehavior
{
    private Coroutine coroutine;

    private float length;
    private float height;
    public AnimForwardBehavior(float length, float height)
    {
        this.length = length;
        this.height = height;
    }

    public void Enter(Transform transform)
    {
        if (this.coroutine != null)
            return;

        this.coroutine = Coroutines.StartRoutine(this.JumpToSide(transform, length, height, transform.position.z, 1.5f));
        length++;
        height++;
    }

    public void Exit()
    {
        Coroutines.StopRoutine(this.coroutine);
        this.coroutine = null;
    }

}
