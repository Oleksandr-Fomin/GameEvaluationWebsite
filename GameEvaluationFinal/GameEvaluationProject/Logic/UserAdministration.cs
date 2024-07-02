
using Logic;
using Logic.Entities;
using Logic.Exceptions;

public class UserAdministration : IUserAdministration
{
    private readonly IUserDBHelper userDBHelper;
    public delegate void UsernameChangedEventHandler(object sender, string newUsername);
    public event UsernameChangedEventHandler UsernameChanged;

    public UserAdministration(IUserDBHelper dbHelper)
    {
        this.userDBHelper = dbHelper;
    }

    public Account VerifyUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return null;
        }

        return userDBHelper.VerifyUser(username, password);
    }

    public bool SaveUser(User user)
    {
        if (user == null || string.IsNullOrEmpty(user.GetUsername()) || string.IsNullOrEmpty(user.GetEmail()) || string.IsNullOrEmpty(user.GetPassword()))
        {
            return false;
        }

        try
        {
            userDBHelper.SaveUser(user);
            Console.WriteLine("User saved successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving user: " + ex.Message);
            return false;
        }
    }

    public User GetUserById(string userId)
    {
        return userDBHelper.GetUserById(userId);
    }

    public List<User> GetAllUsers()
    {
        return userDBHelper.GetAllUsers();
    }

    public Account GetAccountByUsername(string username)
    {
        return userDBHelper.GetAccountByUsername(username);
    }

    public bool UpdateUsername(string currentUsername, string newUsername)
    {
        var result = userDBHelper.UpdateUsername(currentUsername, newUsername);
        if (result)
        {
            OnUsernameChanged(newUsername);
        }
        return result;
    }

    protected virtual void OnUsernameChanged(string newUsername)
    {
        UsernameChanged?.Invoke(this, newUsername);
    }
    public void AddMessage(string userId, string text)
    {
        userDBHelper.AddMessage(userId, text);
    }
    public List<Message> GetMessagesByUserId(string userId)
    {
       return userDBHelper.GetMessagesByUserId(userId);
    }

    public async Task MarkMessageAsRead(int messageId)
    {
        await userDBHelper.MarkMessageAsRead(messageId);
    }

    public static void ValidateUsername(string username)
    {
        if (username.Length < 3)
        {
            throw new CustomException(ErrorCode.InvalidUsername);
        }

        if (username.Any(char.IsWhiteSpace))
        {
            throw new CustomException(ErrorCode.InvalidUsername);
        }
    }

    public static void ValidateEmail(string email)
    {
        if (email.Length < 5 || email.Length > 254)
        {
            throw new CustomException(ErrorCode.InvalidEmail);
        }
    }

    

    public bool UpdateUser(User user)
    {
        if (user == null) throw new ArgumentException("User cannot be null.");

        if (string.IsNullOrWhiteSpace(user.Id)) throw new ArgumentException("User ID is required.");
        {
            return userDBHelper.UpdateUser(user);
        } 
    }


}