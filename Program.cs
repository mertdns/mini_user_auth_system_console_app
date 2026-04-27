List<User> users = new List<User>();
users.Add(new User("mert" , "123"));
users.Add(new User("admin" , "123"));
users.Add(new User("ali" , "1234"));

Console.WriteLine("Programa Hoşgeldiniz, lütfen giriş yapın");
Console.Write("Kullanıcı Adı: ");
string username = Console.ReadLine();
Console.Write("Şifre: ");
string password = Console.ReadLine();

User activeUser = User.Login(new User(username , password) , users);

while(activeUser == null)
{
    Console.Write("Kullanıcı Adı: ");
    username = Console.ReadLine();
    Console.Write("Şifre: ");
    password = Console.ReadLine();
    activeUser = User.Login(new User(username, password), users);
}

string role = activeUser.IsAdmin ? "Admin" : "Kullanıcı";
Console.WriteLine($"Giriş başarılı! Hoşgeldin {activeUser.UserName} Rolün: {role}");
User.MainMenu(activeUser.IsAdmin);
int input = int.Parse(Console.ReadLine());
while(input != 2)
{
    switch (input)
    {
        case 1:
            User.GetAllUserInfo(users);
            break;
        case 3:
            User.GetActiveUserInfo(activeUser.UserName, users);
            break;
        case 4:
            if (activeUser.IsAdmin)
            {
                Console.Write("Silinecek kullanıcı adı: ");
                string usernameToDelete = Console.ReadLine();
                User.DeleteUser(users, usernameToDelete);
            }
            else
            {
                Console.WriteLine("Yetkiniz yok.");
            }
            break;
        default:
            Console.WriteLine("Geçersiz giriş, lütfen tekrar deneyin.");
            break;
    }
    User.MainMenu(activeUser.IsAdmin);
    input = int.Parse(Console.ReadLine());
}
class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsLogin { get; set; }

    public User(string username , string password)
    {
        this.UserName = username;
        this.Password = password;
        this.IsAdmin = false;
        this.IsLogin = false;

        if(username == "admin" && password == "123")
        {
            this.IsAdmin = true;
        }
    }


    public static User Login(User user , List<User> users)
    {
        foreach (var item in users)
        {
            if(item.UserName == user.UserName && item.Password == user.Password)
            {
                item.IsLogin = true;
                return item;
            }
        }
        return null;
    }

    public static void GetAllUserInfo(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine($"Kullanıcı Adı: {user.UserName}");
            Console.WriteLine($"Şifre: {user.Password}");
            Console.WriteLine($"Admin: {user.IsAdmin}");
            Console.WriteLine($"Giriş Durumu: {user.IsLogin}");
            Console.WriteLine("-----------------------------");
        }
    }

    public static void MainMenu(bool IsAdmin)
    {
        string adminString = IsAdmin ? "4 - Kullanıcıyı Sil" : "";

        Console.WriteLine($@"
1 - Tüm Kullanıcı Bilgilerini Görüntüle
2 - Çıkış Yap
3 - Aktif Kullanıcı Bilgilerini Görüntüle
{adminString}
");
    }

    public static void GetActiveUserInfo(string username , List<User> users)
    {
        foreach (var item in users)
        {
            if (item.UserName == username)
            {
                Console.WriteLine($"Kullanıcı Adı: {item.UserName}");
                Console.WriteLine($"Şifre: {item.Password}");
                Console.WriteLine($"Admin: {item.IsAdmin}");
                Console.WriteLine($"Giriş Durumu: {item.IsLogin}");
                Console.WriteLine("-----------------------------");
            }
        }
    }

    public static void DeleteUser(List<User> users, string username)
    {
        User userToDelete = null;
        foreach (var item in users)
        {
            if (item.UserName == username)
            {
                userToDelete = item;
                break;
            }
        }
        if (userToDelete != null)
        {
            users.Remove(userToDelete);
            Console.WriteLine($"{username} adlı kullanıcı silindi.");
        }
        else
        {
            Console.WriteLine($"{username} adlı kullanıcı bulunamadı.");
        }
    }
}

