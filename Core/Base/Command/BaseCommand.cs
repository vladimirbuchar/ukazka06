namespace Core.Base.Command
{
    public abstract class BaseCommand : IBaseCommand { }

    public abstract class BaseCommand<Repository> : BaseCommand
    {
        protected Repository _repository;

        protected BaseCommand(Repository repository)
        {
            _repository = repository;
        }
    }
}
