using DoctorAppointmentDALLibrary;

using DoctorAppointmentModelLibrary;

namespace DoctorAppointmentDALTest
{
    public class PatientRepositoryTest
    {
        IRepository<int, Patient> patientRepository;

        [SetUp]
        public void Setup()
        {
            patientRepository = new PatientRepository();
            Patient patient = new Patient("bhavan", 21);
            patientRepository.Add(patient);
        }

        [Test]
        public void AddNewPatientSuccessTest()
        {
            Patient patient = new Patient("bhavan", 21);
            Patient patientWithId = patientRepository.Add(patient);
            Assert.AreEqual(2, patientWithId.Id);
        }

        [Test]
        public void AddNewPatientFailTest()
        {
            Patient p1 = new Patient("bhavan", 21);
            patientRepository.Add(p1);
            Patient p2WithId = patientRepository.Add(p1);
            Assert.IsNull(p2WithId);
        }

        [Test]
        public void GetOnePatientSuccessTest()
        {
            Assert.NotNull(patientRepository.Get(1));
        }

        [Test]
        public void GetOnePatientFailTest()
        {
            Assert.IsNull(patientRepository.Get(2));
        }

        [Test]
        public void GetAllPatientsSuccessTest()
        {
            List<Patient> patients = patientRepository.GetAll();
            Assert.AreEqual (1, patients.Count);
        }

        [Test]
        public void GetAllPatientsFailTest()
        {
            IRepository<int, Patient> patientRepository = new PatientRepository();
            List<Patient> patients = patientRepository.GetAll();
            Assert.IsNull(patients);
        }

        [Test]
        public void DeletePatientSuccessTest()
        {
            Patient patient = patientRepository.Delete(1);

            Assert.IsNotNull(patient);
        }

        [Test]
        public void DeletePatientFailTest()
        {
            Patient patient = patientRepository.Delete(3);

            Assert.IsNull(patient);
        }

        [Test]
        public void UpdatePatientSuccessTest()
        {
            Patient patient = patientRepository.Get(1);
            patient.Name = "new name";
            Patient updatedPatient = patientRepository.Update(patient); 
            Assert.IsNotNull(updatedPatient);
        }

        [Test]
        public void UpdatePatientFailTest()
        {
            Patient patient = patientRepository.Get(1);
            patient.Id = 5;
            Patient updatedPatient = patientRepository.Update(patient);
            Assert.IsNull(updatedPatient);
        }
    }
}