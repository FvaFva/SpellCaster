using UnityEditor.Experimental.GraphView;
using WorldSpace;

namespace Player
{
    public class Player
    {
        private MoveableBody _body;
        private Position _fightDirection;

        public Player(Position startPosition, Position fightDirection)
        {
            _fightDirection = fightDirection;
            _body = new MoveableBody(startPosition);
            _body.ChangeDirection(fightDirection);
        }

        public Position Position => _body.Position;
        public Position Direction => _body.Direction;


    }
}
