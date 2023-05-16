namespace src.Models;


public class Contract {

  public Contract (){
    this.CreatedAt = DateTime.Now;
    this.Value = 0;
    this.Id = "000";
    this.Pay = false;

  }
  public Contract (string Id, double Value, bool Pay ){
    this.CreatedAt = DateTime.Now;
    this.Value = Value;
    this.Id = Id;
    this.Pay = Pay;
  }

  public DateTime CreatedAt { get; set; }
  public string Id { get; set; }
  public double Value { get; set; }
  public bool Pay { get; set; }
  public int PersonId { get; set; }
};