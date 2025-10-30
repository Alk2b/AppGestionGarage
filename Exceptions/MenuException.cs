using System;

namespace GarageManagementApp.Exceptions
{
    /// <summary>
    /// Exception personnalisée pour les erreurs liées au menu
    /// </summary>
    public class MenuException : Exception
    {
        /// <summary>
        /// Constructeur avec message personnalisé
        /// </summary>
        public MenuException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructeur avec message et exception interne
        /// </summary>
        public MenuException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
