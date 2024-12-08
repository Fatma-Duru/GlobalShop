using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlobalShop.Entity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace GlobalShop.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConnetion")
        {
            

        }
    }
}