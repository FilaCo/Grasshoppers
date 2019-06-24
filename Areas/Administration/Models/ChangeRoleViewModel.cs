using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Grasshoppers.Areas.Administration.Models
{
    public class ChangeRoleViewModel
    {
        public string Id { get; set; }
        
        public string UserName { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}