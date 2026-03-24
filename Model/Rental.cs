namespace apbd_cw2_git_s31225.Model;

public class Rental(Device item, User borrower, DateTime rentalDate, int daysLimit)
{
    public Device Item { get; set; } = item;
    public User Borrower { get; set; } = borrower;
    
    public DateTime RentalDate { get; set; } = rentalDate;
    public DateTime DueDate { get; set; } = rentalDate.AddDays(daysLimit);
    public DateTime? ReturnDate { get; set; } = null; // null = not returned yet
    
    public decimal Penalty { get; set; } = 0; // penalty 
}