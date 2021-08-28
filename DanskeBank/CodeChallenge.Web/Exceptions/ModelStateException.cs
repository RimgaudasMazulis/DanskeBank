using System;

namespace CodeChallenge.Web.Exceptions
{
    public class ModelStateException : Exception
    {
        public ModelStateException()
        {

        }

        public ModelStateException(string message) : base(message)
        {

        }
    }
}