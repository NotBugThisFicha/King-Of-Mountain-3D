using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : GeometryObject
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JumpAlways(SetBehaviorJumpBack));
        iTween.PunchScale(gameObject, iTween.Hash(
            "z", 3f,
            "time", 3f, "easytype", iTween.EaseType.easeInCirc, "LoopType", iTween.LoopType.loop));
    }

}
