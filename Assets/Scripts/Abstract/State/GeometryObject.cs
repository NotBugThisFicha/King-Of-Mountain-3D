using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeometryObject : MonoBehaviour
{

    private Dictionary<Type, IAnimationBehavior> behaviorMap;
    private IAnimationBehavior currentBehavior;

    protected delegate void BehaviorDelegate();

    private void Awake()
    {
        InitBehaviors();

    }
    private void InitBehaviors()
    {
        behaviorMap = new Dictionary<Type, IAnimationBehavior>();

        behaviorMap[typeof(AnimForwardBehavior)] = new AnimForwardBehavior(1, 2);
        behaviorMap[typeof(AnimBackBehavior)] = new AnimBackBehavior();
        behaviorMap[typeof(AnimLeftBehavior)] = new AnimLeftBehavior();
        behaviorMap[typeof(AnimRightBehavior)] = new AnimRightBehavior();
        behaviorMap[typeof(RandomAnimBehavior)] = new RandomAnimBehavior(0);
    }

    protected void SetBehavior(IAnimationBehavior animationBehavior)
    {
        if (currentBehavior != null)
            currentBehavior.Exit();

        currentBehavior = animationBehavior;
        currentBehavior.Enter(transform);
    }

    protected void StopBehavior()
    {
        if (currentBehavior != null)
            currentBehavior.Exit();
    }

    protected IAnimationBehavior GetBehavior<T>() where T : IAnimationBehavior
    {
        var type = typeof(T);
        return behaviorMap[type];
    }


    protected IEnumerator JumpAlways(BehaviorDelegate behavior)
    {
        while (true)
        {
            behavior();
            yield return new WaitForSeconds(1f);
        }
    }

    protected void SetBehaviorJumpForward()
    {
        var behavior = GetBehavior<AnimForwardBehavior>();
        SetBehavior(behavior);
    }

    protected void SetBehaviorJumpBack()
    {
        var behavior = GetBehavior<AnimBackBehavior>();
        SetBehavior(behavior);
    }
    protected void SetBehaviorJumpLeft()
    {
        var behavior = GetBehavior<AnimLeftBehavior>();
        SetBehavior(behavior);
    }

    protected void SetBehaviorJumpRight()
    {
        var behavior = GetBehavior<AnimRightBehavior>();
        SetBehavior(behavior);
    }

    protected void SetBehaviorJumpRandom()
    {
        var behavior = GetBehavior<RandomAnimBehavior>();
        SetBehavior(behavior);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyArea"))
        {
            gameObject.SetActive(false);
        }
    }
}
