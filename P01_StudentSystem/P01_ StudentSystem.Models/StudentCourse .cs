﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.P01__StudentSystem.Models
{
  internal class StudentCourse
  {
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Student student { get; set; }
    public Course course { get; set; }
  }
}