using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace PharmacyManagmentV2.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("numberOfUsers")]
    public class NumberOfUsers : TagHelper
    {
        private readonly AppDBContext _context;
        public NumberOfUsers(AppDBContext context)
        {
            _context = context;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var result = _context.ApplicationUsers.Count<ApplicationUser>().ToString(); 
            
            output.Content.SetContent(result);
        }
    }
}