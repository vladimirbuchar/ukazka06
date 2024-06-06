namespace Core.DataTypes
{
    public abstract class BaseOperation
    {
        public bool OrganizationOwner { get; private set; } = true;
        public bool OrganizationAdministrator { get; protected set; } = false;
        public bool CourseAdministrator { get; protected set; } = false;
        public bool CourseEditor { get; protected set; } = false;
        public bool Lector { get; protected set; } = false;
        public bool Student { get; protected set; } = false;

        public BaseOperation() { }

        public BaseOperation(bool allowAllLoggedUser)
        {
            if (allowAllLoggedUser)
            {
                Student = true;
                Lector = true;
                CourseEditor = true;
                CourseAdministrator = true;
                OrganizationAdministrator = true;
            }
        }
    }
}
