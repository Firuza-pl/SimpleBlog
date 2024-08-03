using AutoMapper;
using Blog.Shared.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace Blog.Application.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDTO>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(IDbConnection dbConnection, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
        }

        //QuerySingle-Use when only one row is expected to be returned. if it return more,fewer, or null it will
        //throw an exception. we use it, when we sure that query return a single result. returns a dynamic type

        //QueryFirst- return multiple rows in result set but we interesed only 1st row of dynamic type.

        //QueryFirstOrDefault -return 1st row of dynamic type or null if there is no result

        //QuerySingleOrDefault- use when zero or one row is excepted to be returned

        //Query- is used to retrive multiple rows in result set, returns IEnumerable<T> when it contains all rows.

        //QuerySingleOrDefault<T> - return an instance of T types

        public async Task<CommentDTO> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var commentDTO = await _dbConnection.QuerySingleOrDefaultAsync<CommentDTO>(@"
                        SELECT 
                            CommentId,
                            PostId,
                            Author,
                            Content,
                            CommentStatusId AS CommentStatus,
                            CreationDate
                        FROM Comments
                        WHERE PostId = @PostId AND CommentId = @CommentId", 
                        new { PostId = request.PostId, CommentId = request.CommentId });

            return commentDTO;
        }
    }

}
