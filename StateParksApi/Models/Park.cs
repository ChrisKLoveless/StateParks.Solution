namespace StateParks.Models
{
  public class Park
  {
    // [Required]
    public int ParkId { get; set; }
    // [Required]
    public string Name { get; set; }
    // [Required]
    public int StateId { get; set; }
  }
}