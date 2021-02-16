namespace Craftsman.Shared.Constants
{
    public static class Message
    {
         public static readonly string ValueNotExistingInTheBrazilianTerritory = "CEP not existing in the Brazilian territory";
         public static readonly string MusteBeAnAdult = "Must be an adult.";

         public static string ThePropertyIsInvalidPleaseVerify(string key)
         => $"The {key} is invalid please verify.";

         public static string InvalidNumberOfCharacters(string key, int min, int max)
         => $"{key} : Invalid number of characters (min: {min} max:{max})";
    }

    public static class PropertyName
    {
        public static readonly string ZipCode = "zipcode";
        public static readonly string CPF = "cpf";
        public static readonly string Email = "e-mail";
        public static readonly string Name = "name";
        public static readonly string FullName = "full_name";
        public static readonly string City = "city";
        public static readonly string Street = "street";
        public static readonly string Country = "country";
    }
}