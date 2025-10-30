using System;

namespace GarageManagementApp.Exceptions
{
    /// <summary>
    /// Exception levée lorsqu'une option n'est pas trouvée
    /// </summary>
    public class OptionNotFoundException : Exception
    {
        public OptionNotFoundException(string message) : base(message)
        {
        }

        public OptionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
