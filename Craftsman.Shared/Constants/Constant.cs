namespace Craftsman.Shared.Constants
{
    public static class Constant
    {
        public readonly static Message Message = new();
        public readonly static Key Key = new();
    }

    public class Message
    {
         public readonly string ValueNotExistingInTheBrazilianTerritory = "CEP not existing in the Brazilian territory";
    }

    public class Key
    {
        public readonly string ZipCode = "zipcode";
    }
}