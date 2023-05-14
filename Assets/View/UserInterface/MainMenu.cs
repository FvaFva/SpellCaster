using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _enemyRequester;

    public event Action EnemyRequested;

    private void OnEnable()
    {
        _enemyRequester.onClick.AddListener(OnEnemyRequest);
    }

    private void OnDisable()
    {
        _enemyRequester.onClick.RemoveListener(OnEnemyRequest);
    }

    private void OnEnemyRequest()
    {
        EnemyRequested?.Invoke();
    }
}
