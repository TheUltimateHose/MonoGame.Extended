using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Demo.Solitare
{
    public class DragHandler
    {
        public DragHandler()
        {
        }

        private Vector2 _mouseStartPosition;
        private Vector2 _offset;

        public IMovable Target { get; private set; }
        public Vector2 TargetStartPosition { get; private set; }

        public void StartDrag(Point mousePosition, IMovable target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            Target = target;
            TargetStartPosition = target.Position;
            _mouseStartPosition = mousePosition.ToVector2();
            _offset = _mouseStartPosition - target.Position;
        }

        public void Drag(Point mousePosition)
        {
            if(Target != null)
                Target.Position = mousePosition.ToVector2() - _offset;
        }

        public void EndDrag()
        {
            Target = null;
        }
    }
}