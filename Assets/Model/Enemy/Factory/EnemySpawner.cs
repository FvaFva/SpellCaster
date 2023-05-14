using System;
using System.Collections.Generic;
using WorldSpace;
using WorldSpace.EnemyPath;

namespace FightSpace
{
    namespace EnemyFactory
    {
        public class EnemySpawner
        {
            private List<Enemy> _allEnemies = new List<Enemy>();
            private EnemyPath _path;

            public EnemySpawner(List<Position> path) 
            {
                if (path == null || path.Count == 0)
                    return;

                _path = new EnemyPath(path[0]);

                for (int i = 1; i < path.Count; i++) 
                {
                    _path.AddPoint(path[i]);
                }
            }

            public event Action<Enemy> EnemySpawned;

            public void SpawnEnemy()
            {
                Enemy enemy = new Enemy(100, 8, _path);
                _allEnemies.Add(enemy);
                EnemySpawned?.Invoke(enemy);
            }
        }
    }
}