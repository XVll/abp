using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity
{
    public class GetIdentityClaimTypeInput: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}