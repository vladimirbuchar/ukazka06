namespace Core.DataTypes
{
    public class SystemError(string errorCode) : ValidationMessage(MessageType.SYSTEM_ERROR, errorCode) { }
}
