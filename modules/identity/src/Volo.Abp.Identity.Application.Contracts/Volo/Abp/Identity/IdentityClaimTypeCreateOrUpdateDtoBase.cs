using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Volo.Abp.Identity
{
    public class IdentityClaimTypeCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(typeof(IdentityClaimTypeConsts), nameof(IdentityClaimTypeConsts.MaxNameLength))]
        public string Name { get; set; }

        public bool Required { get; set; }


        [CanBeNull]
        [DynamicStringLength(typeof(IdentityClaimTypeConsts), nameof(IdentityClaimTypeConsts.MaxRegexLength))]
        public string Regex { get; set; }

        [CanBeNull]
        [DynamicStringLength(typeof(IdentityClaimTypeConsts), nameof(IdentityClaimTypeConsts.MaxRegexDescriptionLength))]
        public string RegexDescription { get; set; }

        [CanBeNull]
        [DynamicStringLength(typeof(IdentityClaimTypeConsts), nameof(IdentityClaimTypeConsts.MaxDescriptionLength))]
        public string Description { get; set; }
        [Required]
        public IdentityClaimValueType ValueType { get; set; }

        protected IdentityClaimTypeCreateOrUpdateDtoBase() : base(false)
        {
            
        }
    }
}