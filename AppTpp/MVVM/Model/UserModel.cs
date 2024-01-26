namespace AppTpp.MVVM.Model
{
    public class UserModel
    {
        public string Nip { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Jabatan { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Privilege { get; set; } = string.Empty;
        public byte[]? ProfileImage { get; set; }
    }
}
