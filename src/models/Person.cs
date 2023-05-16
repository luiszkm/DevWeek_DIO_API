namespace src.Models
{
  public class Person
  {
    public Person(string Name, int Age, string Cpf, bool IsActive, int  Id)
    {
      this.Id = Id;
      this.Name = Name;
      this.Age = Age;
      this.Cpf = Cpf;
      this.IsActive = IsActive;
      this.Contracts = new List<Contract>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Cpf { get; set; }
    public bool IsActive { get; set; }
    public List<Contract> Contracts { get; set; }
  }
}