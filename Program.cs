using apbd_cw2_git_s31225.Model;
using apbd_cw2_git_s31225.Services;

namespace apbd_cw2_git_s31225;

class Program
{
    static void Main(string[] args)
    {
        RentalService service = new RentalService();

        Laptop laptop1 = new Laptop("Laptop 1", "MSI GF 63", true, 16, "i5");
        Projector projector1 = new Projector("Projector 1", "Acer P5535", true, "1080p", 4500);
        Camera camera1 = new Camera("Camera 1", "Nikon Z50II", true, "CMOS", "EXPEED 7");

        service.AddDevice(laptop1);
        service.AddDevice(projector1);
        service.AddDevice(camera1);

        Student student1 = new Student("Student 1", "Jan", "Kowalski", "s12345", "IT");
        Employee employee1 = new Employee("Employee 1", "Anna", "Nowak", "e54321", "APBD");

        service.AddUser(student1);
        service.AddUser(employee1);

        Console.WriteLine("--- Rental succeed ---");
        service.RentDevice("Student 1", "Laptop 1");

        Console.WriteLine("\n--- Renting unavailable device ---");
        service.RentDevice("Employee 1", "Laptop 1");

        Console.WriteLine("\n--- Exceeding the student's limit ---");
        service.RentDevice("Student 1", "Projector 1");
        service.RentDevice("Student 1", "Camera 1");

        Console.WriteLine("\n--- Returning device ---");
        service.ReturnDevice("Laptop 1");
        
        Console.WriteLine("\n--- Returning device with penalty ---");
        DateTime date = DateTime.Now.AddDays(20);
        service.ReturnDevice("Projector 1", date);

        service.ShowReport();
    }
}