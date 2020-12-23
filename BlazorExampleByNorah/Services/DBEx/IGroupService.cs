using BlazorExampleByNorah.Models;
using BlazorExampleByNorah.ViewModels;

namespace BlazorExampleByNorah.Services
{
    interface IGroupService
    {
        PaginatedItemsViewModel<GroupItem> GetGroupItemsPaginated(int pageSize, int pageIndex);

        GroupItem GetGroupItem(string code);

        bool UpdateGroupItem(string code, GroupItem groupItem);

        bool CreateGroupItem(GroupItem groupItem);

        bool DeleteGroupItem(string code);
    }
}
