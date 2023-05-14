using FightSpace;
using FightSpace.EnemyFactory;
using System.Collections.Generic;
using UnityEngine;
using View;
using WorldSpace;
using System.Linq;

public class Game : MonoBehaviour
{
    [SerializeField] EnemyAvatarsFactory _avatarsFactory;
    [SerializeField] MainMenu _mainMenu;
    [SerializeField] List<PathPosition> _path;

    private EnemySpawner _enemySpawner;

    private void OnEnable()
    {
        _enemySpawner = new EnemySpawner(_path.Select(point => point.Position).ToList());
        _enemySpawner.EnemySpawned += OnEnemySpawn;
        _mainMenu.EnemyRequested += OnEnemyRequest;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemySpawned -= OnEnemySpawn;
        _mainMenu.EnemyRequested -= OnEnemyRequest;
    }

    private void OnEnemyRequest()
    {
        _enemySpawner.SpawnEnemy();
    }

    private void OnEnemySpawn(Enemy enemy)
    {
        _avatarsFactory.InitEnemy(enemy);
    }
}
