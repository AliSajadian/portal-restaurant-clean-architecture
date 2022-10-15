namespace Portal.Domain.BaseInfo.Models;

public class ModelConstants
{
    public class Common
    {
        public const int MinNameLength = 1;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 5;
        public const int MaxDescriptionLength = 1200;
    }

    public class Employee
    {
        public const int MinPersonnelCodeLength = 1;
        public const int MaxPersonnelCodeLength = 6;
    }
}