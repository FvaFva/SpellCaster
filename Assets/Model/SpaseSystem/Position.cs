using System;

namespace WorldSpace
{
    public struct Position
    {
        private float _x;
        private float _y;
        private float _z;

        public Position(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Position(float x, float y, float z, bool normalize)
        {
            float sum = Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
            _x = x / sum;
            _y = y / sum;
            _z = z / sum;
        }

        public float X => _x;
        public float Y => _y;
        public float Z => _z;

        public bool IsSame(Position position)
        {
            return _x == position.X && _y == position.Y && _z == position.Z;
        }

        public bool IsInRadius(Position verifiable, float radius)
        {
            return Math.Sqrt(Math.Abs(_x - verifiable.X)) + Math.Sqrt(Math.Abs(_z - verifiable.Z)) <= Math.Sqrt(radius);
        }
    }
}