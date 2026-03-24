using apbd_cw2_git_s31225.Model;

namespace apbd_cw2_git_s31225.Services;

public class RentalService
{
    public List<Device> Devices = new List<Device>();
    public List<User> Users = new List<User>();
    public List<Rental> Rentals = new List<Rental>();

    public void AddDevice(Device device)
    {
        Devices.Add(device);
    }
    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void RentDevice(string userId, string deviceId)
    {
        User user = null;
        foreach (var u in Users) if (u.Id == userId) user = u;
        
        Device device = null;
        foreach (var d in Devices) if (d.Id == deviceId) device = d;

        if (user == null || device == null) return;

        if (!device.IsAvailable)
        {
            Console.WriteLine("Device is not available");
            return;
        }
        int activeRentals = 0;
        foreach (var r in Rentals)
        {
            if (r.Borrower.Id == userId && r.ReturnDate == null)
            {
                activeRentals++;
            }
        }

        int limit = (user is Student) ? 2 : 5;
        if (activeRentals >= limit)
        {
            Console.WriteLine("Limit exceeded");
            return;
        }
        device.IsAvailable = false;
        Rental rental = new Rental(device, user, DateTime.Now, 7);
        Rentals.Add(rental);
        Console.WriteLine($"Rented {device.Name} for {user.Surname}");
    }

    public void ReturnDevice(string deviceId, DateTime? returnDate = null)
    {
        DateTime actualReturnDate = returnDate ?? DateTime.Now;
        foreach (var r in Rentals)
        {
            if (r.Item.Id == deviceId && r.ReturnDate == null)
            {
                r.ReturnDate = actualReturnDate;
                r.Item.IsAvailable = true;
                
                if (r.ReturnDate > r.DueDate)
                {
                    var delay = (r.ReturnDate.Value - r.DueDate).Days;
                    if (delay > 0)
                    {
                        r.Penalty = delay * 20;
                        Console.WriteLine($"Return delayed for {r.Item.Name}! Penalty: {r.Penalty} PLN ({delay} days).");
                    }
                }
                else 
                {
                    Console.WriteLine($"{r.Item.Name} returned on time.");
                }
                return;
            }
        }
        Console.WriteLine("No active rental found for this device.");
    }

    public void ShowReport()
    {
            Console.WriteLine("Current state of devices:");
            foreach (var d in Devices)
            {
                string status = d.IsAvailable ? "Available" : "Rented";
                Console.WriteLine($"{d.Name}: {status}");
            }
    }
}