using System;

namespace GarageManagementApp.Exceptions
{
    /// <summary>
    /// Exception levée lorsqu'un moteur n'est pas trouvé
    /// </summary>
    public class MoteurNotFoundException : Exception
    {
        public MoteurNotFoundException(string message) : base(message)
        {
        }

        public MoteurNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
