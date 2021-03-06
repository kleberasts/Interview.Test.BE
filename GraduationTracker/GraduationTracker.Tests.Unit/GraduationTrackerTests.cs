﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.DML;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();

            #region Arrange
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new List<Requirement> {
                    new Requirement { Id = 100 },
                    new Requirement { Id = 102 },
                    new Requirement { Id = 103 },
                    new Requirement { Id = 104 }
                }
            };

            var students = new List<Student> {
                new Student {
                    Id = 1,
                    Courses = new List<Course> {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                    }
                },
                new Student {
                    Id = 2,
                    Courses = new List<Course> {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                    }
                },
                new Student {
                    Id = 3,
                    Courses = new List<Course> {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                    }
                },
                new Student {
                    Id = 4,
                    Courses = new List<Course> {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                }

            };
            #endregion

            #region Act
            var graduated = new List<Tuple<bool, STANDING, int>>();

            foreach(Student student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }
            #endregion
            
            #region Assert
            Assert.IsTrue(graduated.Any(x => x.Item3 >= diploma.Credits));
            #endregion
        }


    }
}
