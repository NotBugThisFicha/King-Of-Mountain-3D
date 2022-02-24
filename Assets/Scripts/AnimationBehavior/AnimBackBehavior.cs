using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBackBehavior : Jumps, IAnimationBehavior
{
    private Coroutine coroutine;

    private float length;
    private float height;
    public void Enter(Transform transform)
    {
        if (this.coroutine != null)
            return;

        this.coroutine = Coroutines.StartRoutine(this.JumpToSide(transform, transform.position.x - 1, transform.position.y - 1, transform.position.z, 3));
    }

    public void Exit()
    {
        Coroutines.StopRoutine(this.coroutine);
        this.coroutine = null;
    }
}
