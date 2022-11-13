namespace LSys_DB.Entities
{
    public class UserRoleList //Użyto tabeli łączącej ze względu na mozliwość dodania dodatkowych infomracji np data dodania relacji do tabeli
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
