using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    public static UnityEvent OnDetectColliderEvent = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            OnDetectColliderEvent?.Invoke();
    }

}
