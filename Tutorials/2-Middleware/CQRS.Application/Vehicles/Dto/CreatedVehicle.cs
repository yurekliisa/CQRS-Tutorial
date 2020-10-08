namespace CQRS.Application.Vehicles.Dto
{
    public class CreatedVehicle
    {
        public int Id { get; }
        public CreatedVehicle(int id)
        {
            Id = id;
        }
    }
}
