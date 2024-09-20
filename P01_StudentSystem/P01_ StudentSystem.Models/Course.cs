using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.P01__StudentSystem.Models
{
  internal class Course
  {
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public int Price { get; set; }
    public ICollection<Student> Students { get; }=new List<Student>();
    public ICollection<Resource> Resources { get; }=new List<Resource>();
    public ICollection<Homework> Homeworks {  get; }=new List<Homework>(); 
  }
}
