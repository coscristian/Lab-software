using System.Text.RegularExpressions;

namespace GestionInventario.Common.Validations.Products;

public static partial class Product
{
    public static class Name
    {
        private const int MinimumLength = 3;
        private const int MaximumLength = 50;
        public static bool AreValidCharacters(string name)
        {
            const string pattern = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ' -]+$";
            return new Regex(pattern).IsMatch(name);
        }

        public static bool IsValidMinimumLength(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= MinimumLength;
        }

        public static bool IsValidMaximumLength(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length <= MaximumLength;
        }

        public static bool ContainsMultipleSpaces(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            var regex = new Regex(@"\s{2,}");

            return regex.IsMatch(name);
        }
    }
    
    
}