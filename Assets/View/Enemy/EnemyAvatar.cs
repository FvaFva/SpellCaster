using UnityEngine;
using FightSpace;
using WorldSpace;
using System.Collections;

namespace View
{
    internal class EnemyAvatar : MonoBehaviour
    {
        private Enemy _enemy;
        private Coroutine _lifeProcessing;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            UpdateSubscribe(true);
        }

        private void OnDisable()
        {
            UpdateSubscribe(false);
        }

        public bool IsFree => gameObject.activeSelf == false;

        public void Render(Enemy enemy)
        {
            gameObject.SetActive(true);
            UpdateSubscribe(false);
            _enemy = enemy;
            UpdateSubscribe(true);
            UpdatePosition();
        }

        private void UpdateSubscribe(bool isActive)
        {
            if(_lifeProcessing != null)
                StopCoroutine(_lifeProcessing);

            if (_enemy == null)
                return;

            _enemy.Moved -= UpdatePosition;
            _enemy.Died -= OnEnemyDied;
            _enemy.Finished -= OnEnemyDied;

            if (isActive)
            {
                _lifeProcessing = StartCoroutine(LifeProcessing());
                _enemy.Moved += UpdatePosition;
                _enemy.Died += OnEnemyDied;
                _enemy.Finished += OnEnemyDied;
            }
        }

        private IEnumerator LifeProcessing()
        {
            yield return null;

            while(true)
            {
                _enemy.LiveProcessing(Time.deltaTime);
                yield return null;
            }
        }

        private void OnEnemyDied()
        {
            UpdateSubscribe(false);
            gameObject.SetActive(false);
        }

        private void UpdatePosition()
        {
            Position position = _enemy.CurrentPosition;
            transform.position = new Vector3(position.X, position.Y, position.Z);
        }
    }
}
