namespace ClinicAPI.Exceptions
{
    public class NoDoctorsAvailableException : Exception
    {
        public NoDoctorsAvailableException() : base("No doctors are available!") { }
    }
}
