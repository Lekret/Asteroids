using System;

namespace Model
{
    public interface IDestroyable
    {
        event Action Destroyed;
    }
}