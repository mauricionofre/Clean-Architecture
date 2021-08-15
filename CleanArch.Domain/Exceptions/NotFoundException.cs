using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public const string MESSAGE = "Not Found";

        public NotFoundException() : base(message: MESSAGE)

        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}