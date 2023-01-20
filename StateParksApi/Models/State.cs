namespace StateParks.Models
{
  public class State
  {
    // [Required]
    public int StateId { get; set; }
    // [Required]
    public string Name { get; set; }
    // [Required]
    public int ParkId { get; set; }
  }
}