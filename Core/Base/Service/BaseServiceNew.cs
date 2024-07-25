namespace Core.Base.Service
{
    public abstract class BaseServiceNew : IBaseServiceNew
    {
    }

    public abstract class BaseServiceNew<Repository> : BaseServiceNew
    {
        protected Repository _repository;
        protected BaseServiceNew(Repository repository)
        {
            _repository = repository;
        }
    }



}
