using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WorldSpace
{
    namespace EnemyPath
    {
        public class EnemyPath
        {
            private List<EnemyPathPoint> _points = new List<EnemyPathPoint>();

            public EnemyPath(Position start) 
            {
                Start = start;
                AddPoint(Start);
            }

            public Position Start { get; private set; }

            public void AddPoint(Position point)
            {
                if (IsUniquePoint(point))
                    _points.Add(new EnemyPathPoint(point));
            }

            public bool IsPathContinued(Position current, out Position next)
            {
                next = default(Position);
                bool isPathContinued = false;

                var currentPositions = _points.Where(point => point.Position.IsSame(current));

                if (IsUniquePoint(current, out EnemyPathPoint currentPosition) == false)
                {
                    EnemyPathPoint nextPoint = GetNext(currentPosition);

                    if (nextPoint != null)
                    {
                        next = nextPoint.Position;
                        isPathContinued = true;
                    }
                }

                return isPathContinued;
            }

            private EnemyPathPoint GetNext(EnemyPathPoint current)
            {
                EnemyPathPoint[] pathsTail = _points.SkipWhile(pos => pos != current).ToArray();

                if (pathsTail.Count() == 1)
                    return null;
                else
                    return pathsTail[1];
            }

            private bool IsUniquePoint(Position verifiablePoint, out EnemyPathPoint point)
            {
                List<EnemyPathPoint> points = GetSamePoints(verifiablePoint);
                point = points.FirstOrDefault();
                return point == null;
            }

            private bool IsUniquePoint(Position verifiablePoint)
            {
                return GetSamePoints(verifiablePoint).Count() == 0;
            }

            private List<EnemyPathPoint> GetSamePoints(Position verifiablePoint)
            {
                return _points.Where(point => point.Position.IsSame(verifiablePoint)).ToList();
            }
        }
    }
}