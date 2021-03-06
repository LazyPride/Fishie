﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public abstract class Entity : Drawable
    {
        public Character Character { set;  get; }
        public bool IsAlive { get; set; }
        public Entity()
        {
            IsAlive = true;
        }
        public abstract void HandleInput();
        public abstract void RegisterEventHandlers(RenderWindow target);
        public abstract void Update(float deltaTime);
        public abstract void Draw(RenderTarget target, RenderStates states);
        protected abstract void DoTouch(Entity entity);
        protected abstract void DoDetach(Entity entity);
        public void OnTouch(Entity entity)
        {
            contactEntities.Add(entity);
            DoTouch(entity);
        }
        public void OnDetach(Entity entity)
        {
            DoDetach(entity);
            contactEntities.Remove(entity);
        }
        public bool HasContact(Entity entity)
        {
            foreach (Entity e in contactEntities)
            {
                if (entity == e)
                {
                    return true;
                }
            }
            return false;
        }

        private List<Entity> contactEntities = new List<Entity>();

    }
}
