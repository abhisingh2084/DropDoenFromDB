﻿using System;
using System.Collections.Generic;

namespace DropDoenFromDB.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public string StudnetGender { get; set; } = null!;
        public int Age { get; set; }
        public int Standard { get; set; }
    }
}
