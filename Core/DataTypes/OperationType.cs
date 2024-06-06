namespace Core.DataTypes
{
    public class OperationType(BaseOperation operation)
    {
        public BaseOperation SelectOperation { private set; get; } = operation;
        public bool OrganizationOwner => SelectOperation.OrganizationOwner;
        public bool OrganizationAdministrator => SelectOperation.OrganizationAdministrator;
        public bool CourseAdministrator => SelectOperation.CourseAdministrator;
        public bool CourseEditor => SelectOperation.CourseEditor;
        public bool Lector => SelectOperation.Lector;
        public bool Student => SelectOperation.Student;
    }
}
