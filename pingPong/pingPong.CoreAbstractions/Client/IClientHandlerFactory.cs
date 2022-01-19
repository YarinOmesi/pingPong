
namespace pingPong.CoreAbstractions.Client
{
    internal interface IClientHandlerFactory<TIn,TOut>
    {
        IClientHandler<TIn> Create(IClientWriter<TOut> writer);
    }
}
