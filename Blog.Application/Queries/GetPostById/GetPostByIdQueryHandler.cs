using AutoMapper;
using Blog.Domain.Entities.PostAggregate;
using Blog.Shared.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace Blog.Application.Queries.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostWithCommentsDTO>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }

        public async Task<PostWithCommentsDTO> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            //NOTES: QueryMultiple- execute multi queries in a single SQL and return GridReader. allows us to select multi result from db queries,
            //it is usefull to select multiple result at once from different tables , it avoids unnecessary trips to db server every time.
            //once executed we can map result to multiple object using methods, such as Read<T>

            var sql = @"
                SELECT 
	                PostId,
	                Title,
	                Introduction,
	                Content,
	                CreationDate, 
	                ModificationDate
                FROM Posts
                WHERE PostId = @PostId AND IsRemoved = 0;

                SELECT 
	                CommentId,
                    PostId, 
	                Author,
	                Content,
                    CommentStatusId AS CommentStatus,
	                CreationDate
                FROM Comments
                WHERE 
	                PostId = @PostId
	                AND CommentStatusId = @CommentStatusId
                ORDER BY CreationDate DESC;";

            PostWithCommentsDTO postDTO = null;
            using (var multi = await _dbConnection.QueryMultipleAsync(sql, 
                new { 
                    PostId = request.PostId, 
                    CommentStatusId = (int)CommentStatus.Accepted 
                }))
            {
                postDTO = multi.Read<PostWithCommentsDTO>().SingleOrDefault();
                if (postDTO != null)
                {
                    postDTO.Comments = multi.Read<PostWithCommentsDTO.CommentDTO>().ToList();
                }
            }

            return postDTO;
        }
    }

}
