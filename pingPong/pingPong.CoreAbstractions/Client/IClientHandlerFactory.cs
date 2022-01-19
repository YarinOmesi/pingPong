
namespace pingPong.CoreAbstractions.Client
{
    public interface IClientHandlerFactory<TIn,TOut>
    {
        IClientHandler<TIn> Create(IClientWriter<TOut> writer);
    }
}
