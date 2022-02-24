using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject VFXPlayer;

    public delegate void GameCondition(float condition);
    public static event GameCondition GameConditionEvent;

    // Start is called before the first frame update
    private void OnEnable()
    {
        PlayerController.OnDetectPlayerDeath += ReloadScene;
    }

    private void OnDisable()
    {
        PlayerController.OnDetectPlayerDeath -= ReloadScene;
    }
    private void ReloadScene(GameObject player)
    {
        Instantiate(VFXPlayer, player.transform.position, Quaternion.identity);
        Destroy(player);
        StartCoroutine(Reload());
    }

    public void PauseGame()
    {
        
        PlayerController.Instance.enabled = false;
        GameConditionEvent?.Invoke(1);
        Invoke("TimeScale", 1f);
    }

    private void TimeScale()
    {
        Time.timeScale = 0;
    }
    
    public void ResumeGame()
    {
        GameConditionEvent?.Invoke(0);
        Time.timeScale = 1;
        Invoke("PlayerEnabled", 1f);
    }

    private void PlayerEnabled()
    {
        PlayerController.Instance.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
