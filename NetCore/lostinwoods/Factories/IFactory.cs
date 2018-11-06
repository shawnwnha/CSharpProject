using lostinwoods.Models;
using System.Collections.Generic;

namespace lostinwoods.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}