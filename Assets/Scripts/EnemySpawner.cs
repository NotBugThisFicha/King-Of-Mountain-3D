using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private CubeFactory cubeFactory;
    [SerializeField] private ParaPipedFactory paraPipedFactory;
    [SerializeField] private CylinderFactory cylinderFactory;

    [SerializeField] private Transform transformSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cubeFactory.CoroutineInstance(transformSpawn);
        paraPipedFactory.CoroutineInstance(transformSpawn);
        cylinderFactory.CoroutineInstance(transformSpawn);
    }

  
}
