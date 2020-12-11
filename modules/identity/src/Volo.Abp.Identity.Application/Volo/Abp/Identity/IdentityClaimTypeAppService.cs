using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.Identity
{
    [Authorize(IdentityPermissions.ClaimType.Default)]
    public class IdentityClaimTypeAppService : IdentityAppServiceBase, IIdentityClaimTypeAppService
    {
        protected IdentityClaimTypeManager ClaimTypeManager { get; }
        protected IIdentityClaimTypeRepository ClaimTypeRepository { get; }

        public IdentityClaimTypeAppService(
            IdentityClaimTypeManager claimTypeManager,
            IIdentityClaimTypeRepository claimTypeRepository)
        {
            ClaimTypeManager = claimTypeManager;
            ClaimTypeRepository = claimTypeRepository;
        }

        //
        public async Task<IdentityClaimTypeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<IdentityClaimType, IdentityClaimTypeDto>(await ClaimTypeRepository.GetAsync(id));
        }

        public async Task<ListResultDto<IdentityClaimTypeDto>> GetAllListAsync()
        {
            var claimTypes = await ClaimTypeRepository.GetListAsync();
            return new ListResultDto<IdentityClaimTypeDto>(
                ObjectMapper.Map<List<IdentityClaimType>, List<IdentityClaimTypeDto>>(claimTypes));
        }

        public async Task<PagedResultDto<IdentityClaimTypeDto>> GetListAsync(GetIdentityClaimTypeInput input)
        {
            var claimTypes = await ClaimTypeRepository.GetListAsync(input.Sorting, input.MaxResultCount,
                input.SkipCount,
                input.Filter);
            var totalCount = await ClaimTypeRepository.GetCountAsync();
            return new PagedResultDto<IdentityClaimTypeDto>(totalCount,
                ObjectMapper.Map<List<IdentityClaimType>, List<IdentityClaimTypeDto>>(claimTypes));
        }

        [Authorize(IdentityPermissions.ClaimType.Create)]
        public async Task<IdentityClaimTypeDto> CreateAsync(IdentityClaimTypeCreateDto input)
        {
            var claimType = new IdentityClaimType(GuidGenerator.Create(), input.Name, input.Required, false,
                input.Regex, input.RegexDescription, input.Description, input.ValueType);
            input.MapExtraPropertiesTo(claimType);
            await ClaimTypeManager.CreateAsync(claimType);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<IdentityClaimType, IdentityClaimTypeDto>(claimType);
        }

        [Authorize(IdentityPermissions.ClaimType.Update)]
        public async Task<IdentityClaimTypeDto> UpdateAsync(Guid id, IdentityClaimTypeUpdateDto input)
        {
            var claimType = await ClaimTypeRepository.GetAsync(id);
            claimType.ConcurrencyStamp = input.ConcurrencyStamp;

            claimType.SetName(input.Name);
            claimType.SetValueType(input.ValueType);

            claimType.Required = input.Required;
            claimType.Description = input.Description;
            claimType.Regex = input.Regex;
            claimType.RegexDescription = input.RegexDescription;

            input.MapExtraPropertiesTo(claimType);

            await ClaimTypeManager.UpdateAsync(claimType);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<IdentityClaimType, IdentityClaimTypeDto>(claimType);
        }

        [Authorize(IdentityPermissions.ClaimType.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            var claimType = ClaimTypeRepository.FindAsync(id);
            if (claimType == null)
            {
                return;
            }

            await ClaimTypeRepository.DeleteAsync(id);
        }
    }
}