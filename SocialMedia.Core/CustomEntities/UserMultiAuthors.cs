namespace SocialMedia.Core.CustomEntities
{
    public class UserMultiAuthors
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int CantidadUsuariosDiferentes { get; set; }
    }
}
