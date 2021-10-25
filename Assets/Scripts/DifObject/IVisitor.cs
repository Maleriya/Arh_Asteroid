

namespace Asteroids
{
    public interface IVisitor
    {
        void Visit(Asteroid enemy);
        void Visit(Kometa enemy);
    }
}
