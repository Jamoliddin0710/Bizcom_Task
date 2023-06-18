namespace Bizcom_Task.Entities.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}
