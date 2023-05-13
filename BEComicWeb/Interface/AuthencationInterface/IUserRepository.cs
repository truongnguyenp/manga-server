using BEComicWeb.Model.AuthencationModel;

namespace BEComicWeb.Interface.AuthencationInterface
{
    public interface IUserRepository
    {
        public Users? getUser(string? id);
        public List<Users>? getAllUsers();
        public UserInfo? getUserInfo(string? id);
        public UserInfo? updateUserInfo(UserInfo userinfo);
        public string? getUserImage(string? id);
        public string? updateUserImage(string? user_id, string new_image);
    }
}
