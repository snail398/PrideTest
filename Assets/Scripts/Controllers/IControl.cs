using TankSpace;
using GunSpace;

namespace Control
{
    public interface IControl
    {
        void SetControl(Tank tank, Gun gun);
    }
}
