using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.Identity
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("ClaimType")]
    [Route("api/identity/claimTypes")]
    public class IdentityClaimTypeController: AbpController, IIdentityClaimTypeAppService
    {
        protected IIdentityClaimTypeAppService ClaimTypeAppService { get; }
        public IdentityClaimTypeController(IIdentityClaimTypeAppService claimTypeAppService)
        {
            ClaimTypeAppService = claimTypeAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<IdentityClaimTypeDto>> GetListAsync(GetIdentityClaimTypeInput input)
        {
            return await ClaimTypeAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ListResultDto<IdentityClaimTypeDto>> GetAllListAsync()
        {
            return await ClaimTypeAppService.GetAllListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IdentityClaimTypeDto> GetAsync(Guid id)
        {
            return await ClaimTypeAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IdentityClaimTypeDto> CreateAsync(IdentityClaimTypeCreateDto input)
        {
            return await ClaimTypeAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IdentityClaimTypeDto> UpdateAsync(Guid id, IdentityClaimTypeUpdateDto input)
        {
            return ClaimTypeAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return ClaimTypeAppService.DeleteAsync(id);
        }

    }
}
