using Blog.Application.Exceptions;
using Blog.Domain.Core;
using Blog.Domain.Repositories.Interfaces;
using MediatR;

namespace Blog.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentCommandHandler(IPostsRepository postsRepository, IUnitOfWork unitOfWork)
        {
            _postsRepository = postsRepository;
            _unitOfWork = unitOfWork;
        }

        //Unit-part of Mediatr library, used to represent return type of method that don't have meaningful return value.
        //shows succesful execution of method without need to returning any data
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _postsRepository.GetByIdAsync(request.PostId);
            if (post == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.PostAggregate.Post), request.PostId);
            }

            post.AddComment(request.CommentId, request.Author, request.Content);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
