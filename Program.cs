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

        Console.WriteLine("Rental succeed");
        service.RentDevice("Student 1", "Laptop 1");

        Console.WriteLine("\nRenting unavailable device");
        service.RentDevice("Employee 1", "Laptop 1");

        Console.WriteLine("\nExceeding the student's limit");
        service.RentDevice("Student 1", "Projector 1");
        service.RentDevice("Student 1", "Camera 1");

        Console.WriteLine("\nReturning device");
        service.ReturnDevice("Laptop 1");
        
        Console.WriteLine("\nReturning device with penalty");
        DateTime date = DateTime.Now.AddDays(20);
        service.ReturnDevice("Projector 1", date);

        Console.WriteLine("\nShowing ONLY available devices");
        service.ShowAvailableDevices();
        
        Console.WriteLine("\nMarking Camera 1 as damaged");
        service.SetDeviceUnavailable("Camera 1");
        service.RentDevice("Employee 1", "Camera 1");
        
        Console.WriteLine("\nActive rentals for Jan Kowalski");
        service.RentDevice("Student 1", "Laptop 1");
        service.ShowUserRentals("Student 1");
        
        Console.WriteLine("\nLate rentals report");
        service.ShowLateRentals();
        
        service.ShowReport();
    }
}