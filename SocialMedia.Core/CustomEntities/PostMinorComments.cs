namespace SocialMedia.Core.CustomEntities
{
    public class PostMinorComments
    {
        public int IdPost { get; set; }
        public string PostDescription { get; set; } = string.Empty;
        public int CantidadComentariosMenores { get; set; }
    }
}
