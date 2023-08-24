namespace FoodOrderSystemAPI.DAL;

public class AdminRepo : EntityRepo<AdminModel>, IAdminRepo
{
    public AdminRepo(SystemContext dbContext) : base(dbContext)
    {
    }
}
