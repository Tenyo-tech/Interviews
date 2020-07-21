using GreenVsRed.Engine.Initializations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed.Engine.Contracts
{
    public interface IEngine
    {
        void Initialize();

        void Start(IFieldInitialization fieldInitialization);
    }
}
