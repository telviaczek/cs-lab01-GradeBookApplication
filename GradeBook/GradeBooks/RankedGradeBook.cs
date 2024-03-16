using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var listOfGrades = Students.Select(x => x.AverageGrade).OrderByDescending(x=> x).ToList();
            var top = listOfGrades.Count / 5f;
            var highestCount = 0f;
            var result = 5;
            foreach (var grade in listOfGrades)
            {
                if (averageGrade >= grade) break;

                highestCount++;
                if (highestCount >= top)
                {
                    highestCount -= top;
                    result--;
                }

            }
            return result switch
            {
                5 => 'A',
                4 => 'B',
                3 => 'C',
                2 => 'D',
                _ => 'F'

            };
        }


        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            
        }
    }
}
