using System.Windows.Forms;

namespace Models
{
    public interface IMoveable
    {
        void Move(KeyEventArgs e);
        void OnShapeMovement(Direction direction);
    }
}
