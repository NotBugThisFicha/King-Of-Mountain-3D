using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRightBehavior : Jumps, IAnimationBehavior
{
    private Coroutine coroutine;


    public void Enter(Transform transform)
    {
        if (this.coroutine != null)
            return;

        this.coroutine = Coroutines.StartRoutine(this.JumpToSide(transform, transform.position.x, transform.position.y, transform.position.z - 1, 1.5f));
    }

    public void Exit()
    {
        Coroutines.StopRoutine(this.coroutine);
        this.coroutine = null;
    }
}
