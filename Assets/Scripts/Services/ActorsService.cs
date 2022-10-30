using System.Collections.Generic;
using Base;

namespace Services
{
    public interface IActorsService
    {
        void RegisterActor(int actorId, Actor actor);
        Actor GetActor(int actorId);
    }
    
    public class ActorsService: IActorsService
    {
        private readonly Dictionary<int, Actor> _actors = new();
        
        public void RegisterActor(int actorId, Actor actor)
        {
            if (!_actors.ContainsKey(actorId))
            {
                _actors.Add(actorId, actor);
            }
        }

        public Actor GetActor(int actorId)
        {
            return _actors.ContainsKey(actorId) ? _actors[actorId] : null;
        }
    }
}