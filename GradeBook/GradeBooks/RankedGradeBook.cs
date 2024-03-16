﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else {
                base.CalculateStatistics();

            }
        }
    }
}
