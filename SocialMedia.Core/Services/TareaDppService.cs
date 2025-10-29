using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class TareaDppService : ITareaDppService
    {
        private readonly ITareaDppRepository _tareaDppRepository;

        public TareaDppService(ITareaDppRepository tareaDppRepository)
        {
            _tareaDppRepository = tareaDppRepository;
        }

        public async Task<IEnumerable<UserNoComments>> GetUserNoCommentsAsync()
        {
            return await _tareaDppRepository.GetUserNoCommentsAsync();
        }

        public async Task<IEnumerable<RecentComments25>> GetRecentComments25Async()
        {
            return await _tareaDppRepository.GetRecentComments25Async();
        }

        public async Task<IEnumerable<PostNoActiveComments>> GetPostNoActiveCommentsAsync()
        {
            return await _tareaDppRepository.GetPostNoActiveCommentsAsync();
        }

        public async Task<IEnumerable<UserMultiAuthors>> GetUserMultiAuthorsAsync()
        {
            return await _tareaDppRepository.GetUserMultiAuthorsAsync();
        }

        public async Task<IEnumerable<PostMinorComments>> GetPostMinorCommentsAsync()
        {
            return await _tareaDppRepository.GetPostMinorCommentsAsync();
        }
    }
}
