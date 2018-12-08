using Castle.Core.Logging;

namespace SenseFramework.Core.Messaging
{
    using IoC;

    public static class Messanger
    {
        public static ILogger Logger => IoCManager.Container.Resolve<ILogger>();
    }
}
