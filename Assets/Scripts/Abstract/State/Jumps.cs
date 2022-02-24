using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jumps
{
    protected float animTime = 0.4f;
    protected float animTimeChange = 2f;

    protected IEnumerator JumpToSide(Transform transform, float length, float height, float z, float heightJump)
    {
   
        var expiredSeconds = 0f;
        var progress = 0f;

        float stabilizeX;
        float stabilizeY;
        float stabilizeZ;

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / animTime;

            if (transform != null)
                transform.position = MathfParabola.Parabola(transform.position, new Vector3(length, height, z), heightJump, progress);
            else yield break;
            yield return null;
        }

        if (transform != null)
        {
            stabilizeX = Mathf.Round(transform.position.x);
            stabilizeY = Mathf.Round(transform.position.y);
            stabilizeZ = Mathf.Round(transform.position.z);

            transform.position = new Vector3(stabilizeX, stabilizeY, stabilizeZ);
        }
            

    }


    protected IEnumerator JumpAlways(Transform transform, float length, float height, float z)
    {
        while (true)
        {
            var expiredSeconds = 0f;
            var progress = 0f;

            while (progress < 1f)
            {
                expiredSeconds += Time.deltaTime;
                progress = expiredSeconds / animTimeChange;

                if (transform != null)
                    transform.position = MathfParabola.Parabola(transform.position, new Vector3(length, height, z), 3f, progress);
                else yield break;

                yield return null;
            }
            length -= Random.Range(1, 3);
            height = length + 1;
            z = Random.Range(-2f, 2f);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
