using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Enum;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class TareaDppRepository : ITareaDppRepository
    {
        private readonly DapperContext _dapper;

        public TareaDppRepository(DapperContext dapper)
        {
            _dapper = dapper;
        }

        // 1 Usuarios activos que no han realizado ningún comentario
        public async Task<IEnumerable<UserNoComments>> GetUserNoCommentsAsync()
        {
            var sql = @"
                SELECT 
                    u.FirstName,
                    u.LastName,
                    u.Email
                FROM [dbo].[User] u
                LEFT JOIN [dbo].[Comment] c ON u.Id = c.UserId
                WHERE c.Id IS NULL
                  AND u.IsActive = 1;
            ";

            return await _dapper.QueryAsync<UserNoComments>(sql);
        }

        // 2 Comentarios realizados 3 meses atrás por usuarios mayores de 25 años
        public async Task<IEnumerable<RecentComments25>> GetRecentComments25Async()
        {
            var sql = @"
                SELECT 
                    c.Id AS IdComment,
                    c.Description AS CommentDescription,
                    u.FirstName,
                    u.LastName,
                    DATEDIFF(YEAR, u.DateOfBirth, GETDATE()) AS Edad
                FROM [dbo].[Comment] c
                INNER JOIN [dbo].[User] u ON c.UserId = u.Id
                WHERE c.DateComment >= DATEADD(MONTH, -3, GETDATE())
                  AND DATEDIFF(YEAR, u.DateOfBirth, GETDATE()) > 25;
            ";

            return await _dapper.QueryAsync<RecentComments25>(sql);
        }

        // 3 Posts sin comentarios de usuarios activos
        public async Task<IEnumerable<PostNoActiveComments>> GetPostNoActiveCommentsAsync()
        {
            var sql = @"
                SELECT 
                    p.Id AS IdPost,
                    p.Description AS PostDescription,
                    p.Date AS PostDate
                FROM [dbo].[Post] p
                LEFT JOIN [dbo].[Comment] c ON p.Id = c.PostId
                LEFT JOIN [dbo].[User] u ON c.UserId = u.Id AND u.IsActive = 1
                WHERE c.Id IS NULL;
            ";

            return await _dapper.QueryAsync<PostNoActiveComments>(sql);
        }

        // 4 Usuarios que han comentado en posts de diferentes usuarios (al menos 3)
        public async Task<IEnumerable<UserMultiAuthors>> GetUserMultiAuthorsAsync()
        {
            var sql = @"
                SELECT 
                    u.FirstName,
                    u.LastName,
                    COUNT(DISTINCT p.UserId) AS CantidadUsuariosDiferentes
                FROM [dbo].[Comment] c
                INNER JOIN [dbo].[User] u ON c.UserId = u.Id
                INNER JOIN [dbo].[Post] p ON c.PostId = p.Id
                GROUP BY u.FirstName, u.LastName
                HAVING COUNT(DISTINCT p.UserId) >= 3;
            ";

            return await _dapper.QueryAsync<UserMultiAuthors>(sql);
        }

        // 5 Posts con comentarios de usuarios menores de edad
        public async Task<IEnumerable<PostMinorComments>> GetPostMinorCommentsAsync()
        {
            var sql = @"
                SELECT 
                    p.Id AS IdPost,
                    p.Description AS PostDescription,
                    COUNT(c.Id) AS CantidadComentariosMenores
                FROM [dbo].[Post] p
                INNER JOIN [dbo].[Comment] c ON p.Id = c.PostId
                INNER JOIN [dbo].[User] u ON c.UserId = u.Id
                WHERE DATEDIFF(YEAR, u.DateOfBirth, GETDATE()) < 18
                GROUP BY p.Id, p.Description;
            ";

            return await _dapper.QueryAsync<PostMinorComments>(sql);
        }
    }
}
