using System;
using static UnityEngine.GraphicsBuffer;

namespace WorldSpace
{
    public class MoveableBody
    {
        private float _x;
        private float _y;
        private float _z;

        public MoveableBody(Position startPosition)
        {
            _x = startPosition.X;
            _y = startPosition.Y;
            _z = startPosition.Z;
        }

        public Position Position => new Position(_x, _y, _z);
        public Position Direction { get; private set; }

        public void Move(float speed)
        {
            _x += speed * Direction.X;
            _y += speed * Direction.Y;
            _z += speed * Direction.Z;
        }

        public void ChangeDirection(Position target)
        {
            Direction = new Position(target.X - _x, target.Y - _y, target.Z - _z, true);
        }
    }
}
