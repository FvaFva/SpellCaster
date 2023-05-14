using System;
using WorldSpace;
using WorldSpace.EnemyPath;

namespace FightSpace
{
    public class Enemy
    {
        private float _hitPoints;
        private float _speed;
        private MoveableBody _body;
        private EnemyPath _path;
        private Position _target;

        public Enemy(float hitPoints, float speed, EnemyPath path)
        {
            _hitPoints = hitPoints;
            _path = path;
            _speed = speed;
            _body = new MoveableBody(_path.Start);
            _target = CurrentPosition;
        }

        public Position CurrentPosition => _body.Position;
        public event Action Moved;
        public event Action Died;
        public event Action Finished;

        public void ApplyDamage(int  damage)
        {
            if (_hitPoints <= 0 || damage <= 0)
                return;

            _hitPoints -= damage;

            if (_hitPoints <= 0)
                Died?.Invoke();
        }

        public void LiveProcessing(float delay)
        {
            _body.Move(_speed * delay);
            Moved?.Invoke(); 
            CheckDirection();
        }

        private void CheckDirection()
        {
            if(_target.IsInRadius(CurrentPosition, 1))
            {
                if (_path.IsPathContinued(_target, out _target))
                    _body.ChangeDirection(_target);
                else
                    OnPathFinish();
            }
        }

        private void OnPathFinish()
        {
            Finished?.Invoke();
            _body.ChangeDirection(CurrentPosition);
        }
    }
}
