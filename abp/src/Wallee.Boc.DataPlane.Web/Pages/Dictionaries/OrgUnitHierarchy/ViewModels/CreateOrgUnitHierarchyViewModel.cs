using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Wallee.Boc.DataPlane.Web.Pages.Dictionaries.OrgUnitHierarchy.ViewModels;

public class CreateOrgUnitHierarchyViewModel
{
    [Display(Name = "OrgUnitHierarchyParentId")]
    [HiddenInput]
    public Guid? ParentId { get; set; }

    [Required]
    [Display(Name = "OrgUnitHierarchyName")]
    public string Name { get; set; } = default!;
    [Required]
    [Display(Name = "OrgUnitHierarchyIdentity")]
    public string Identity { get; set; } = default!;
}
