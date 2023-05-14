using FightSpace;
using UnityEngine;

namespace View
{
    public class EnemyAvatarsFactory : MonoBehaviour
    {
        [SerializeField] int _volumeHub;
        [SerializeField] EnemyAvatar _enemyPrefab;

        private EnemyAvatarsHub _hub = new EnemyAvatarsHub();

        private void Awake()
        {
            for (int i = 0; i < _volumeHub; i++)
            {
                InstantiateAvatar();
            }
        }

        public void InitEnemy(Enemy enemy)
        {
            EnemyAvatar avatar = _hub.GetFree();

            if (avatar == null)
                avatar = InstantiateAvatar();

            avatar.Render(enemy);
        }

        private EnemyAvatar InstantiateAvatar()
        {
            EnemyAvatar newAvatar = Instantiate(_enemyPrefab, transform.position, default(Quaternion), transform);
            _hub.Put(newAvatar);
            return newAvatar;
        }
    }
}
