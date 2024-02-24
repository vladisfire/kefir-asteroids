﻿namespace Infrastructure.ECS
{
    public partial struct Entity
    {
        public int index { get; internal set; }

        public static bool operator ==(Entity a, Entity b)
        {
            return a.index == b.index && a.index == b.index;
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public int CompareTo(Entity other)
        {
            return index - other.index;
        }

        public override int GetHashCode()
        {
            return index;
        }

        public bool Equals(Entity entity)
        {
            return entity.index == index;
        }

        public override string ToString()
        {
            return index >= 0 ? $"Entity [ {index} ]" : $"Entity [ null ]"; 
        }
    }
}