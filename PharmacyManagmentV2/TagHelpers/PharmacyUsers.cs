﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using BusinessLayer.Concrete;
namespace PharmacyManagmentV2.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("getPharmacyUsers")]
    public class PharmacyUsers : TagHelper
    {
        private readonly PharmcyManager _pharmacyManager;
        public PharmacyUsers(PharmcyManager pharmcyManager)
        {
            _pharmacyManager = pharmcyManager;
        }

        public int PharmacyId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string Usernames = "";
           var users = _pharmacyManager.GetUsers(PharmacyId).Select(I => I.UserName);

            foreach (var item in users)
            {
                Usernames += item + " ";
            }

            output.Content.SetContent(Usernames);
        }
    }
}
