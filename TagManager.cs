using System;
using System.Collections.Generic;
namespace Artemis
{
	public sealed class TagManager {
		private World world;
		private Dictionary<String, Entity> entityByTag = new Dictionary<String, Entity>();
	
		public TagManager(World world) {
			this.world = world;
		}
	
		public void Register(String tag, Entity e) {
			entityByTag.Add(tag, e);
		}
	
		public void Unregister(String tag) {
			entityByTag.Remove(tag);
		}
	
		public bool IsRegistered(String tag) {
			return entityByTag.ContainsKey(tag);
		}
	
		public Entity GetEntity(String tag) {
            Entity e;
            bool hasTag = entityByTag.TryGetValue(tag, out e);
            if (e == null || e.IsActive())
            {
                return e;
            }
            else
            {
                Unregister(tag);
                return null;
            }
		}
	
	}
}

