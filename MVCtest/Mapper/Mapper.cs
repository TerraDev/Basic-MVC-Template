using MVCtest.Domain;
using MVCtest.ViewModels;

namespace MVCtest.Mapping
{
    internal static class Mapper
    {
        internal static ItemViewModel ItemToVM(Item item)
        {
            return new ItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                field1 = item.field1,
                ImagePath = String.IsNullOrEmpty(item.ImageName) ? null : "/Images/Items/" + item.ImageName,
                UserName = item?.User?.UserName,
                Description = item.description
            };
        }

        internal static Item VMtoItem(ItemViewModel itemModel)
        {
            return new Item()
            {
                Id = itemModel.Id,
                Name = itemModel.Name,
                field1 = itemModel.field1,
                ImageName = itemModel.ImagePath,
                description = itemModel.Description
            };
        }

        internal static UserViewModel UsertoVM(AppUser user)
        {
            return new UserViewModel(user.Id)
            {
                userName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                Latitude = user.Latitude,
                Longitude = user.Longitude,
                // get roles in controller/service
            };
        }

        internal static AppUser VMtoUser(UserViewModel userModel)
        {
            return new AppUser()
            {
                UserName = userModel.userName,
                Email = userModel.Email,
                Address = userModel.Address,
                Latitude = userModel.Latitude,
                Longitude = userModel.Longitude,
                Id = userModel.userId
                // set roles in controller/service
            };
        }
    }
}
