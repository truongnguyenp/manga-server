using BEComicWeb.Model.AuthencationModel;
using BEComicWeb.Model.ImageModel;
using System.IdentityModel.Tokens.Jwt;

namespace BEComicWeb.Interface.AuthencationInterface
{
    public interface IUserRepository
    {
        public Users? getUser(string? id);
        public List<Users>? getAllUsers();
        public UserInfo? getUserInfo(string? id);
        public UserInfo? updateUserInfo(UserInfo userinfo);
        public Image? getUserImage(string? id);
        public Image? updateUserImage(string? user_id, Image new_image);
    }
}
