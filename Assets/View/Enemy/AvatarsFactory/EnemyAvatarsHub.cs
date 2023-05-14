using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    internal class EnemyAvatarsHub
    {
        private List<EnemyAvatar> _enemyAvatars = new List<EnemyAvatar>();

        public void Put(EnemyAvatar avatar)
        {
            _enemyAvatars.Add(avatar);
        }

        public EnemyAvatar GetFree()
        {
            var allFree = _enemyAvatars.Where(avatar => avatar.IsFree);
            return allFree.FirstOrDefault();
        }
    }
}