using System.Collections.Generic;
using System.Linq;

namespace Core.DataTypes
{
    public class Result
    {
        private readonly List<ValidationMessage> validationMessages;
        public List<ValidationMessage> Errors => [.. validationMessages.Where(x => x.Type is MessageType.ERROR or MessageType.SYSTEM_ERROR).OrderBy(x => x.Priority)];
        public bool IsError => Errors.Count > 0;
        public bool DataChanged { get; set; } = false;
        public bool IsOk => !IsError;
        public Result()
        {
            validationMessages = [];
        }

        public void AddResultStatus(ValidationMessage validationMessage)
        {
            validationMessages.Add(validationMessage);
        }

        public void AddResultStatus(List<ValidationMessage> validationMessages)
        {
            foreach (ValidationMessage validationMessage in validationMessages)
            {
                this.validationMessages.Add(validationMessage);
            }
        }

        public bool Contains(ValidationMessage validationMessage)
        {
            return validationMessages.Any(x => x.BasicCode == validationMessage.BasicCode);
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
