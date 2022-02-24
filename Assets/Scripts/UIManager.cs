using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    [SerializeField] private CanvasGroup UICanvasGroope;
    private float timeBlackScreenAnim = 1;

    [SerializeField] private Button pauseGame_B;
    [SerializeField] private Button stopGame_B;
    [SerializeField] private Button resumeGame_B;

    private bool panelActiv = true;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameConditionEvent += SwitchGame;
        PlayerController.OnDetectPlayerStep.AddListener(PunchScore);
    }

    private void PunchScore()
    {
        iTween.PunchScale(scoreText.gameObject, iTween.Hash(
                              "x", 1.5f, "y", 1.5f, "z", 1.5f, "time", 0.4f,
                              "easyType", iTween.EaseType.easeInBack));
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {PlayerController.Instance.stepScore}";
        if(UICanvasGroope.alpha > 0.98 && panelActiv)
        {
            scoreText.gameObject.SetActive(false);
            stopGame_B.gameObject.SetActive(true);
            resumeGame_B.gameObject.SetActive(true);
            pauseGame_B.gameObject.SetActive(false);
            
        }
    }

    private void SwitchGame(float fade)
    {
        if (fade == 1)
            panelActiv = true;
        else panelActiv = false;
        StartCoroutine(FadeTo(UICanvasGroope, fade, timeBlackScreenAnim));
        if(fade == 0)
        {
            pauseGame_B.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            stopGame_B.gameObject.SetActive(false);
            resumeGame_B.gameObject.SetActive(false);
        }


    }

    private void OnDisable()
    {
        GameManager.GameConditionEvent -= SwitchGame;
    }
    IEnumerator FadeTo(CanvasGroup canvasGroup, float aValue, float aTime)
    {
        float alpha = canvasGroup.alpha;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            canvasGroup.alpha = Mathf.Lerp(alpha, aValue, t);
            yield return null;
        }
        yield break;
    }
}
