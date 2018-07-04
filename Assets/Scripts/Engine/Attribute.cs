using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

namespace Engine
{
    public interface IAttribute
    {
        string Name { get; set; }

        string Description { get; }

        float Value { get; set; }

        void Apply(IShip obj);

        void Apply(IComponent obj);

        void Apply(IFacility obj);
    }

    class ShieldAttribute : IAttribute, IEquatable<ShieldAttribute>
    {
        public ShieldAttribute()
        {
            Name = "Simple Shields";
            Value = 50;
        }

        public string Name { get; set; }

        public float Value { get; set; }

        public string Description
        {
            get { return string.Format("Generates {0} points of shields.", Value); }
        }

        public void Apply(IShip obj)
        {
            obj.MaxShieldAmount += Value;
        }

        public void Apply(IComponent obj)
        {    
        }

        public void Apply(IFacility obj)
        {
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ShieldAttribute);
        }

        public bool Equals(ShieldAttribute other)
        {
            return other != null &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }

    public interface IAttributeAcceptor
    {
        void Accept(IAttribute attribute);
    }

    public interface IShip : IAttributeAcceptor
    {
        IEnumerable<IComponent> Components { get; }

        float MaxShieldAmount { get; set; }   

        float CurrentShieldAmount { get; set; }
    }

    public interface IComponent : IAttributeAcceptor
    {
        IEnumerable<IAttribute> Attributes { get; }
    }

    public interface IFacility : IAttributeAcceptor
    {
        IEnumerable<IAttribute> Attributes { get; }
    }
}
