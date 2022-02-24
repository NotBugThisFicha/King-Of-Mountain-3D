using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryGeneric<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private string prefabName;

    [Header("Random time for InstCoroutine")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;



    public T GetNewPoolInstance(Transform transform)
    {
        return Pooler.Instance.SpawnFromPool(prefabName, new Vector3(transform.position.x, transform.position.y, Random.Range(-2, 2)), Quaternion.identity) as T;
    }

    public void CoroutineInstance(Transform transform) => StartCoroutine(SpawnerCoroutine(transform));

    private IEnumerator SpawnerCoroutine(Transform transform)
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        while (true)
        {
            if (transform != null)
            {
                var prefab = GetNewPoolInstance(transform);
                yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            }
            else yield break;
        }
    }

}
