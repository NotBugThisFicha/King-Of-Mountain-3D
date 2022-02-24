using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LedderGenerator : MonoBehaviour
{

    private List<List<GameObject>> ledderList = new List<List<GameObject>>();

    [SerializeField] private GameObject steper;

    private Pooler poolerStep;

    private int oneStep;
    private int oneStepHeight = 0;

    private int destroyStep = 0;


    private void Start()
    {
        poolerStep = Pooler.Instance;
        PlayerController.OnDetectStepDelete.AddListener(StepDestroy);
        PlayerController.OnDetectPlayerStep.AddListener(StepLedderGenerate);
        GenerateLedder(0, 5, 0);
        oneStep = ledderList.Count;
    }

    private void GenerateLedder(int startStep, int length, int height)
    {
        Debug.Log(poolerStep);

        for (int w = startStep; w <= length; w++)
        {
            ledderList.Add(new List<GameObject>());
            for (int h = w; h >= height; h--)
            {
                ledderList[w].Add(poolerStep.SpawnFromPool("Step", new Vector3(w, h, 0), Quaternion.identity));
                //ledderList[w].Add(Instantiate(steper, new Vector3(w, h, 0), Quaternion.identity));
            }
        }
    }

    private void StepDestroy()
    {
        ledderList[destroyStep].ForEach(x => x.gameObject.SetActive(false));
        ledderList[destroyStep].RemoveAll(x => x);
        destroyStep++;
        
    }

    private void StepLedderGenerate()
    {
        GenerateLedder(oneStep, oneStep, oneStepHeight);
        oneStep++;
        oneStepHeight++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
