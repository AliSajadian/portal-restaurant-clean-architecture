namespace Portal.Domain.Common.Models;

public class ModelConstants
{
    public class Common
    {
        public const int MinNameLength = 1;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 5;
        public const int MaxDescriptionLength = 500;
        public const string AdministratorRoleName = "Administrator";
    }

    public class Identity
    {
        public const int MinEmailLength = 3;
        public const int MaxEmailLength = 50;
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 32;
    }
}