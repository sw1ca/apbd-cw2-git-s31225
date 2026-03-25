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
        foreach (var rental in Rentals)
        {
            if (rental.Item.Id == deviceId && rental.ReturnDate == null)
            {
                rental.ReturnDate = actualReturnDate;
                rental.Item.IsAvailable = true;
                
                if (rental.ReturnDate > rental.DueDate)
                {
                    var delay = (rental.ReturnDate.Value - rental.DueDate).Days;
                    if (delay > 0)
                    {
                        rental.Penalty = delay * 20;
                        Console.WriteLine($"Return delayed for {rental.Item.Name}! Penalty: {rental.Penalty} PLN ({delay} days).");
                    }
                }
                else 
                {
                    Console.WriteLine($"{rental.Item.Name} returned on time.");
                }
                return;
            }
        }
        Console.WriteLine("No active rental found for this device.");
    }

    public void SetDeviceUnavailable(string deviceId)
    {
        foreach (var device in Devices)
        {
            if (device.Id == deviceId)
            {
                device.IsAvailable = false;
                Console.WriteLine($"Device {device.Name} marked as unavailable (service/damage).");
                return;
            }
        }
    }

    public void ShowAvailableDevices()
    {
        Console.WriteLine("Available devices only");
        foreach (var device in Devices)
        {
            if (device.IsAvailable)
            {
                Console.WriteLine($"- {device.Name} (ID: {device.Id})");
            }
        }
    }
    public void ShowLateRentals()
    {
        foreach (var rental in Rentals)
        {
            if (rental.ReturnDate == null && DateTime.Now > rental.DueDate)
            {
                Console.WriteLine($"Late rental: {rental.Item.Name} by {rental.Borrower.Surname}");
            }
        }
    }

    public void ShowUserRentals(string userId)
    {
        Console.WriteLine($"Active rentals for user ID: {userId} ");
        foreach (var rental in Rentals)
        {
            if (rental.Borrower.Id == userId && rental.ReturnDate == null)
            {
                Console.WriteLine($"- {rental.Item.Name} (Due: {rental.DueDate.ToShortDateString()})");
            }
        }
    }
    public void ShowReport()
    {
            Console.WriteLine("Current state of devices:");
            foreach (var device in Devices)
            {
                string status = device.IsAvailable ? "Available" : "Rented";
                Console.WriteLine($"{device.Name}: {status}");
            }
    }
}