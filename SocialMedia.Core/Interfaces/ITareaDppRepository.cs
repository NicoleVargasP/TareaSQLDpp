using SocialMedia.Core.CustomEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface ITareaDppRepository
    {
        Task<IEnumerable<UserNoComments>> GetUserNoCommentsAsync();
        Task<IEnumerable<RecentComments25>> GetRecentComments25Async();
        Task<IEnumerable<PostNoActiveComments>> GetPostNoActiveCommentsAsync();
        Task<IEnumerable<UserMultiAuthors>> GetUserMultiAuthorsAsync();
        Task<IEnumerable<PostMinorComments>> GetPostMinorCommentsAsync();
    }
}
