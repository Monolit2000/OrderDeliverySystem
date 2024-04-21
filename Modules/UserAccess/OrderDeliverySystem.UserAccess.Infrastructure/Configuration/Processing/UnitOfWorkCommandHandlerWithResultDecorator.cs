using MediatR;
using OrderDeliverySystem.CommonModule.Infrastructure;
using OrderDeliverySystem.UserAccess.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : IRequestHandler<T, TResult>
         where T : IRequest<TResult>
    {
        private readonly IRequestHandler<T, TResult> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserAccessContext _userAccessContext;

        public UnitOfWorkCommandHandlerWithResultDecorator(
            IRequestHandler<T, TResult> decorated,
            IUnitOfWork unitOfWork,
            UserAccessContext userAccessContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _userAccessContext = userAccessContext;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await this._decorated.Handle(command, cancellationToken);

            //if (command is InternalCommandBase<TResult>)
            //{
            //    var internalCommand = await _userAccessContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

            //    if (internalCommand != null)
            //    {
            //        internalCommand.ProcessedDate = DateTime.UtcNow;
            //    }
            //}

            await this._unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
