using UnityEngine;

namespace Asteroids.Prototype
{
    internal sealed class ExamplePrototype : MonoBehaviour
    {
        private void Start()
        {
            PlayerData playerData = new PlayerData();
            playerData.Hp = new HP() { currentHP = 10, maxHP = 15 };
            playerData.Speed = 50;

            PlayerData playerDataCopy = playerData;
            PlayerData playerDataDeepCopy = playerData.DeepCopy<PlayerData>();

            Debug.Log(playerData.ToString());
            Debug.Log(playerDataCopy.ToString());
            Debug.Log(playerDataDeepCopy.ToString());


            playerData.Hp.maxHP = 100;

            Debug.Log(playerData.ToString());
            Debug.Log(playerDataCopy.ToString());
            Debug.Log(playerDataDeepCopy.ToString());
        }
    }
}
