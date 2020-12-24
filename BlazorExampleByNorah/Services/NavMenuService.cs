using BlazorExampleByNorah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExampleByNorah.Services
{
    public class NavMenuService
    {
        public List<NavMenuModel> GetNavMenuService()
        {
            List<NavMenuModel> menus = new List<NavMenuModel>();

            NavMenuModel model = new NavMenuModel();
            menus.Add(model);

            return menus;
        }
    }
}
