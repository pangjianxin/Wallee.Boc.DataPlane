using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrgUnitHierarchy.ViewModels
{
    public class EditOrgUnitHierarchyViewModel : IHasConcurrencyStamp
    {
        [Display(Name = "OrgUnitHierarchyName")]
        public string Name { get; set; } = default!;

        [Display(Name = "OrgUnitHierarchyIdentity")]
        public string Identity { get; set; } = default!;

        [HiddenInput]
        public string ConcurrencyStamp { get; set; } = default!;
    }
}
