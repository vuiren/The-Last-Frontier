using System;
using System.Collections.Generic;
using Base;

namespace Services
{
    public interface IHealthService
    {
        int GetHealth(int actorId);
        void ChangeHealth(int actorId, int newHealthCount);
        void OnHealthChanged(Action<int> onHealthChanged);
    }
    
    public class HealthService: IHealthService
    {
        private readonly Dictionary<int, int> _healths = new();
        private Action<int> _onHealthChanged;
        

        public int GetHealth(int actorId)
        {
            if (!_healths.ContainsKey(actorId))
            {
                _healths.Add(actorId, 0);
            }

            return _healths[actorId];
        }

        public void ChangeHealth(int actorId, int newHealthCount)
        {
            if (_healths.ContainsKey(actorId))
            {
                _healths[actorId] = newHealthCount;
            }
            else
            {
                _healths.Add(actorId, newHealthCount);
            }
            _onHealthChanged?.Invoke(actorId);
        }

        public void OnHealthChanged(Action<int> onHealthChanged)
        {
            _onHealthChanged += onHealthChanged;
        }
    }
}