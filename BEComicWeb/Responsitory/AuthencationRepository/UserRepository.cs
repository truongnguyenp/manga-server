using BEComicWeb.Data;
using BEComicWeb.Interface.AuthencationInterface;
using BEComicWeb.Model.AuthencationModel;

namespace BEComicWeb.Responsitory.AuthencationRepository
{
    public class UserRepository : IUserRepository
    {
        readonly AppDbContext _dbContext = new();
        public List<Users>? getAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public Users? getUser(string? id)
        {
            var res = _dbContext.Users.Find(id);
            return res;
        }

        public string? getUserImage(string? id)
        {
            var res = _dbContext.Users.Find(id);
            if (res != null)
            {
                return res.UserImage;
            }
            return null;
        }

        public UserInfo? getUserInfo(string? user_id)
        {
            var res = _dbContext.Users.Find(user_id);
            if (res == null)
            {
                UserInfo result = new UserInfo(res);
                return result;
            }
            return null;
        }

        public string? updateUserImage(string? user_id, string new_image)
        {
            var res = _dbContext.Users.Find(user_id);
            if (res != null)
            {
                res.UserImage = new_image;
                _dbContext.SaveChanges();
            }
            return new_image;
        }

        public UserInfo? updateUserInfo(UserInfo userinfo)
        {
            var res = _dbContext.Users.Find(userinfo.Id);
            if (res != null)
            {
                res.Name = userinfo.Name;
                res.Coins = userinfo.Coins;
                res.National = userinfo.National;
                res.LastModified = DateTime.Now;
                _dbContext.SaveChanges();
            }
            return userinfo;
        }
    }
}
