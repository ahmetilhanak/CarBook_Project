using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand updateBannerCommand)
        {
            var value = await _repository.GetByIdAsync(updateBannerCommand.BannerID);

            value.Description = updateBannerCommand.Description;
            value.Title = updateBannerCommand.Title;
            value.VideoDescription = updateBannerCommand.VideoDescription;
            value.VideoUrl = updateBannerCommand.VideoUrl;

            await _repository.UpdateAsync(value);
                    
        }
    }
}
