using System;

namespace GarageManagementApp.Exceptions
{
    /// <summary>
    /// Exception levée lorsqu'un véhicule n'est pas trouvé
    /// </summary>
    public class VehiculeNotFoundException : Exception
    {
        public VehiculeNotFoundException(string message) : base(message)
        {
        }

        public VehiculeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
