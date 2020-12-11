using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Identity
{
    public class IdentityClaimTypeUpdateDto: IdentityClaimTypeCreateOrUpdateDtoBase, IHasConcurrencyStamp
    {
        public string ConcurrencyStamp { get; set; }
    }
}