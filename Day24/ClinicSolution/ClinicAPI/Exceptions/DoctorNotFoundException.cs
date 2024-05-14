namespace ClinicAPI.Exceptions
{
    public class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException(int id) : base($"Doctor with id {id} not found") { }
    }
}
