using UnityEngine;
using Asteroids.State;
using System.Collections.Generic;
using System;
using Asteroids.Command.Second;

namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        public IMove MoveImplementation { get => _moveImplementation; }

        private readonly IRotation _rotationImplementation;
        public IRotation RotationImplementation { get => _rotationImplementation; }

        public float Speed => _moveImplementation.Speed;
        private ShipState _state;
        private Dictionary<Type, ShipState> _states;

        public Ship(IMove moveImplementation, IRotation rotationImplementaton)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementaton;
            FillStates();
            SetDefaultState();
        }

        public void FillStates()
        {
            _states = new Dictionary<Type, ShipState>();
            _states.Add(typeof(ShipStateActive), new ShipStateActive(this));
            _states.Add(typeof(ShipStateDebuff), new ShipStateDebuff(this));
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _state.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _state.Rotation(direction);
        }

        public void AddAcceleration()
        {
            _state.AddAcceleration();
        }

        public void RemoveAcceleration()
        {
            _state.RemoveAcceleration();
        }

        private void SetDefaultState()
        {
            SetActiveState();
        }

        private void SetActiveState()
        {
            _state = _states[typeof(ShipStateActive)];
        }

        private void SetDebuffState()
        {    
            _state = _states[typeof(ShipStateDebuff)];
        }

        public void OnDebuff()
        {
            ServiceLocator.Resolve<UserInterface>().PanelDebuffActive();
            SetDebuffState();
        }

        public void DisableDebuff()
        {
            ServiceLocator.Resolve<UserInterface>().PanelDebuffCancel();
            SetActiveState();
        }

    }
}
