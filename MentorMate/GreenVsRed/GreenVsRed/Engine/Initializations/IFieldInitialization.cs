using GreenVsRed.Field.Contracts;
using GreenVsRed.InputProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Engine.Initializations
{
    public interface IFieldInitialization
    {
        void Initialize(IField field,char[,] gridZero);
    }
}
