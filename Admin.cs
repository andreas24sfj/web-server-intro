class Admin
{
    public string Name = "Andreas";
    public string Username = "gigaadmin";
    public string Password = "ikkeveldigsikkert";

    public bool AuthAdmin(string username, string password)
    {
        return username == Username && password == Password;
    }

}