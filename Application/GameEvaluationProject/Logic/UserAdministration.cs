using GameEvaluationProject;
using Logic;

public class UserAdministration : IUserAdministration
{
    private readonly IDBHelper dbHelper;

    public UserAdministration(IDBHelper dbHelper)
    {
        this.dbHelper = dbHelper;
    }

    public Account VerifyUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return null;
        }

        return dbHelper.VerifyUser(username, password);
    }

    public bool SaveUser(User user)
    {
        if (user == null || string.IsNullOrEmpty(user.GetUsername()) || string.IsNullOrEmpty(user.GetEmail()) || string.IsNullOrEmpty(user.GetPassword()))
        {
            return false;
        }

        try
        {
            dbHelper.SaveUser(user);
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
        return dbHelper.GetUserById(userId);
    }
}