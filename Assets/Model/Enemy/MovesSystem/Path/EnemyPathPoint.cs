namespace WorldSpace
{
    namespace EnemyPath
    {
        internal class EnemyPathPoint
        {
            private Position _position;

            public EnemyPathPoint(Position position)
            {
                _position = position;
            }

            public Position Position => _position;
        }
    }
}