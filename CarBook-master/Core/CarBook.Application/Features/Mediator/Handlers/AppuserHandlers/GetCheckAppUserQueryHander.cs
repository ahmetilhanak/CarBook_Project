using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Responses.AppUserRessponses;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppuserHandlers
{
    public class GetCheckAppUserQueryHander : IRequestHandler<GetCheckAppUserQueryRequest, GetCheckAppUserQueryResponse>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public GetCheckAppUserQueryHander(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResponse> Handle(GetCheckAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            var value = new GetCheckAppUserQueryResponse();
            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            
            if(user == null)
            {
                value.IsExist = false;
            }
            else
            {
                value.Id = user.AppUserId;
                value.Username = user.Username;
                value.Role=(await _appRoleRepository.GetByFilterAsync(z=>z.AppRoleId==user.AppRoleId)).AppRoleName;
                value.IsExist=true;
            }
            return value;
        }
    }
}
