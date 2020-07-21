namespace GreenVsRed
{
    using GreenVsRed.Renders.Contracts;
    using GreenVsRed.Engine.Contracts;
    using GreenVsRed.InputProviders;
    using GreenVsRed.InputProviders.Contracts;
    using GreenVsRed.Renders;
    using Engine;
    using GreenVsRed.Engine.Initializations;

    public class Facade
    {
        public static void Start()
        {
            IRenderer renderer = new Renderer();

            IInputProvider inputProvider = new InputProvider();

            IEngine engine = new GVREngine(renderer,inputProvider);

            IFieldInitialization fieldInitialization = new FieldInitialization();

            engine.Start(fieldInitialization);
        }
    }
}
