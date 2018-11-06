using netcore5.Models;
using System.Collections.Generic;
namespace netcore5.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}