using View;

namespace Configuration
{
    public interface IUfoConfiguration
    {
        float UfoSpeed { get; }
        UfoView UfoPrefab { get; }
    }
}