using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.Identity
{
    public interface IIdentityClaimTypeAppService: ICrudAppService<IdentityClaimTypeDto, Guid, GetIdentityClaimTypeInput, IdentityClaimTypeCreateDto, IdentityClaimTypeUpdateDto>
    {
        Task<ListResultDto<IdentityClaimTypeDto>> GetAllListAsync();
    }
}
