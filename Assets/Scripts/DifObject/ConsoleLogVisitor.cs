
using UnityEngine;

namespace Asteroids
{
    public class ConsoleLogVisitor : IVisitor
    {
        public void Visit(Asteroid enemy)
        {
            Debug.Log($"Астероид {enemy.name} появился на поле боя!");
        }

        public void Visit(Kometa enemy)
        {
            Debug.Log($"Комета {enemy.name} появилась на поле боя!");
        }
    }
}
