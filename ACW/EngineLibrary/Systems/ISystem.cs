using EngineLibrary.Objects;

namespace EngineLibrary.Systems
{
    public interface ISystem
    {
        void OnAction(Entity entity);

        // Property signatures: 
        string Name
        {
            get;
        }
    }
}
