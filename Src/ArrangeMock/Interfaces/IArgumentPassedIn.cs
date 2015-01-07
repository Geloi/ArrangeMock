using System;
using System.Linq.Expressions;

namespace ArrangeMock.Interfaces
{
    public interface IArgumentPassedIn
    {
        void AreSavedTo<T>(Expression<Func<T>> localVariable);
    }
}