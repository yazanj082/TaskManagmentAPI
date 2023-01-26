using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Business.Extensions
{
    public class ConflictException : Exception
    {
        public ConflictException() { }
        public ConflictException(string message) : base(message) { }
    }
    public class ItemNotFoundException : Exception {
        public ItemNotFoundException() { }
        public ItemNotFoundException(string message) : base(message) { }
    }
    public class InvalidDto : Exception
    {
        public InvalidDto() { }
        public InvalidDto(string message) : base(message) { }
    }
    public static class ExceptionManager{
        public static void ThrowItemNotFoundException(string error = "")
        {
            throw new ItemNotFoundException(error);
        }
        public static void ThrowConflictException(string error = "")
        {
            throw new ConflictException(error);
        }
        public static void ThrowInvalidDto(string error = "")
        {
            throw new InvalidDto(error);
        }
    }
}
