using CaseStage.Library.Commands;
using CaseStage.Library.Data;
using CaseStage.Library.Models;
using MediatR;

namespace CaseStage.Library.Handlers
{
    public class AddAreaHandler : IRequestHandler<AddAreaCommand, AreaModel>
    {
        private readonly IDataRepository _dataRepository;

        public AddAreaHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<AreaModel> Handle(AddAreaCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataRepository.AddArea(request.model));
        }
    }
}
