using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : GeometryObject
{

    public static UnityEvent OnDetectPlayerStep = new UnityEvent();
    public static UnityEvent OnDetectStepDelete = new UnityEvent();

    public int stepScore = 0;

    public delegate void PlayerDeath(GameObject gameObject) ;
    public static event PlayerDeath OnDetectPlayerDeath;

    private bool playerisDead;

    public static PlayerController Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        PlayerCollider.OnDetectColliderEvent.AddListener(PlayerDead);

        InputSystem.OnTouchDetect.AddListener(OnPointerDown);
        InputSystem.OnDragRightDetect.AddListener(OnDragRight);
        InputSystem.OnDragLeftDetect.AddListener(OnDragLeft);

    }

    private void OnDestroy()
    {
        PlayerCollider.OnDetectColliderEvent.RemoveListener(PlayerDead);
    }

    public void OnPointerDown()
    {
        if (Instance.enabled == true)
        {
            SetBehaviorJumpForward();
            OnDetectPlayerStep?.Invoke();
            stepScore++;
            if (gameObject.transform.position.y > 5)
                OnDetectStepDelete?.Invoke();
        }
    }

    public void OnDragRight()
    {
        if (Instance.enabled == true)
        {
            SetBehaviorJumpRight();
        }
    }

    public void OnDragLeft()
    {
        if (Instance.enabled == true)
        {
            SetBehaviorJumpLeft();
        }
    }


    private void Update()
    {
        if (transform.position.z < -2.5f && !playerisDead)
        {
            playerisDead = true;
            Instance.enabled = false;
            Invoke("PlayerDead", 1f);
        }

        if(transform.position.z > 2.5f && !playerisDead)
        {
            playerisDead = true;
            Instance.enabled = false;
            Invoke("PlayerDead", 1f);
        }

    }

    private void PlayerDead()
    {
        OnDetectPlayerDeath?.Invoke(gameObject);
    }
}
