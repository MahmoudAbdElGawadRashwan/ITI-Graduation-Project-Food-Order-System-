namespace FoodOrderSystemAPI.DAL;

public interface ICustomerRepo: IEntityRepo<CustomerModel>
{
  public  void RateProduct ();
  public  int MakeOrder ();
  public  void CancelOrder ();
    public void Pay();
    public void Login();
    public void Register();
    public List<CustomerModel> GetAllWithNavProp();
    public CustomerModel GetCustomerByIdWithNavprop(int id);


}
