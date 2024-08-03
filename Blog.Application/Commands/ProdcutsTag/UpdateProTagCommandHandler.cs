using Blog.Application.Exceptions;
using Blog.Domain.Core;
using Blog.Domain.Entities.Tag;
using Blog.Domain.Repositories.Interfaces;
using Blog.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Commands.ProdcutsTag
{
    public class UpdateProTagCommandHandler : IRequestHandler<UpdateProTagCommand>
    {
        private readonly IProductTagsRepository _porductTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProTagCommandHandler(IProductTagsRepository porductTagRepository, IUnitOfWork unitOfWork)
        {
            _porductTagRepository = porductTagRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateProTagCommand request, CancellationToken cancellationToken)
        {
            var protags = await _porductTagRepository.GetProductTagByIdAsync(request.ProductTagId);

            protags.Tag.Status = TagStatus.Created;

            if (protags == null)
            {
                throw new NotFoundException(nameof(ProductTags), request.ProductTagId);
            }

            protags.Edit(request.ProductId, request.TagId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
