using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimBehavior : Jumps, IAnimationBehavior
{
    private Coroutine coroutine;

    private float side = 0;

    public RandomAnimBehavior(float side)
    {
        this.side = side;
    }

    public void Enter(Transform transform)
    {
        if (this.coroutine != null)
            return;

        this.coroutine = Coroutines.StartRoutine(this.JumpAlways(transform, transform.position.x, transform.position.y, side));
        
    }

    public void Exit()
    {
        Coroutines.StopRoutine(this.coroutine);
        this.coroutine = null;
    }
}
