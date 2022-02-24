using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : GeometryObject
{

    // Start is called before the first frame update
    void Start()
    {
        SetBehaviorJumpRandom();
        iTween.RotateTo(gameObject, iTween.Hash(
            "z", 180f,
            "time", 2f, "easytype", iTween.EaseType.easeInBack, "LoopType", iTween.LoopType.loop));
        iTween.ScaleTo(gameObject, iTween.Hash(
            "x", 0.5f,
            "y", 0.5f,
            "z", 0.5f,
            "time", 1f, "easytype", iTween.EaseType.easeInBounce, "LoopType", iTween.LoopType.pingPong));
    }

}
