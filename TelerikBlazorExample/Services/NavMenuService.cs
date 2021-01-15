using TelerikBlazorExample.Models;
using System.Collections.Generic;
using System.IO;

namespace TelerikBlazorExample.Services
{
    public class NavMenuService
    {
        public List<NavMenuModel> GetNavMenuService()
        {
            List<NavMenuModel> menus = new List<NavMenuModel>();

            string pageFolderPath = $"{ Directory.GetCurrentDirectory()}\\Pages";
            List<string> pageFolderList = new List<string>(Directory.EnumerateDirectories(pageFolderPath));
            foreach(string currentFullPath in pageFolderList)
            {
                NavMenuModel model = new NavMenuModel();
                string currentPageFolder = currentFullPath.Replace(pageFolderPath, "");
                model.text = currentPageFolder;
                bool hasMultiFiles = Directory.GetFiles(currentFullPath).Length > 1;
                bool hasMultiFolders = Directory.GetDirectories(currentFullPath).Length > 1;

                if(hasMultiFiles || hasMultiFolders)
                {
                    model.hasSubMenu = true;
                    List<string> fullPathList;
                    if (hasMultiFiles)
                        fullPathList = new List<string>(Directory.EnumerateFiles(currentFullPath));
                    else
                        fullPathList = new List<string>(Directory.EnumerateDirectories(currentFullPath));

                    var subMenuList = new List<NavSubMenu>();
                    foreach(var fullpath in fullPathList)
                    {
                        NavSubMenu subMenuModel = new NavSubMenu();
                        string subPageName = fullpath.Replace($"{pageFolderPath}{currentPageFolder}", "").Split('\\')[1];
                        if(hasMultiFiles) subPageName = subPageName.Split('.')[0];
                        subMenuModel.text = subPageName;
                        subMenuModel.href = $"{currentPageFolder}/{subPageName}";
                        subMenuList.Add(subMenuModel);
                    }
                    model.subMenu = subMenuList;
                }
                else
                {
                    model.hasSubMenu = false;
                    model.href = currentPageFolder;
                }

                menus.Add(model);
            }
            return menus;
        }
    }
}
