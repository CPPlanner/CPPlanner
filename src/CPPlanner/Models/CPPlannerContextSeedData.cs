using CPPlanner.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class CPPlannerContextSeedData
    {
        private CPPlannerContext _context;
        private UserManager<CPPlannerUser> _userManager;

        public CPPlannerContextSeedData(CPPlannerContext context, UserManager<CPPlannerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("test@email.com") == null)
            {
                var user = new CPPlannerUser()
                {
                    UserName = "username",
                    Email = "test@email.com"
                };

                await _userManager.CreateAsync(user, "P@ssw0rd");
            }

            if (!_context.Catalogs.Any())
            {
                Catalog catalog = new Catalog()
                {
                    UserName = "username",
                    Year = 2016,
                    Major = "Computer Science",
                    MinUnitsReq = 180,
                    Modules = new List<Module>()
                    {
                        new Module()
                        {
                            Title = "General Education Requirements",
                            Units = 68,
                            Courses = new List<Course>()
                            {
                                new Course() { Number = "A1", Title = "Oral Communication", Units = 4 },
                                new Course() { Number = "A2", Title = "Written Communication", Units = 4 },
                                new Course() { Number = "A3", Title = "Critical Thinking", Units = 4 },
                                new Course() { Number = "B1", Title = "Physical Science", Units = 4 },
                                new Course() { Number = "B2", Title = "Biological Science", Units = 4 },
                                new Course() { Number = "B3", Title = "Laboratory Activity", Units = 4 },
                                new Course() { Number = "B4", Title = "Mathematics/Quantitative Reasoning", Units = 4 },
                                new Course() { Number = "B5", Title = "Science and Technology Synthesis", Units = 4 },
                                new Course() { Number = "C1", Title = "Visual and Performing Arts", Units = 4 },
                                new Course() { Number = "C2", Title = "Philosophy and Civilization", Units = 4 },
                                new Course() { Number = "C3", Title = "Literature and Foreign Languages", Units = 4 },
                                new Course() { Number = "C4", Title = "Humanitites Synthesis", Units = 4 },
                                new Course() { Number = "D1a", Title = "United States History", Units = 4 },
                                new Course() { Number = "D1b", Title = "Introduction to American Government", Units = 4 },
                                new Course() { Number = "D2", Title = "History, Economics, and Political Science", Units = 4 },
                                new Course() { Number = "D3", Title = "Sociology, Anthropology, Ethnic and Gender Studies", Units = 4 },
                                new Course() { Number = "D4", Title = "Social Science Synthesis", Units = 4 },
                                new Course() { Number = "E", Title = "Lifelong Understanding and Self-development", Units = 4 }
                            }
                        },
                        new Module()
                        {
                            Title = "Required Core Courses for Major",
                            Units = 62,
                            Courses = new List<Course>()
                            {
                                new Course() { Number = "CS 130", Title = "Discrete Structures", Units = 4 },
                                new Course() { Number = "CS 140", Title = "Introduction to Computer Science", Units = 4 },
                                new Course() { Number = "CS 141", Title = "Introduction to Programming and Problem-Solving", Units = 4 },
                                new Course() { Number = "CS 210", Title = "Computer Logic", Units = 4 },
                            }
                        },
                        new Module()
                        {
                            Title = "Elective Core Courses",
                            Units = 23,
                            Courses = new List<Course>()
                            {
                                new Course() { Number = "CS 245", Title = "Programming Graphical User Interfaces", Units = 4 },
                                new Course() { Number = "CS 260", Title = "Unix and Scripting", Units = 4 },
                                new Course() { Number = "CS 352", Title = "Symbolic Programming", Units = 4 },
                                new Course() { Number = "CS 356", Title = "Object-Oriented Design and Programming", Units = 4 },
                            }
                        },
                        new Module()
                        {
                            Title = "Required Support Courses",
                            Units = 43,
                            Courses = new List<Course>()
                            {
                                new Course() { Number = "BIO 110", Title = "Life Science", Units = 3, IsGE = true, GEEquivalent = "B2, B3" },
                                new Course() { Number = "BIO 111L", Title = "Life Science", Units = 1, IsGE = true, GEEquivalent = "B2, B3" },
                                new Course() { Number = "CS 375", Title = "Computers and Society", Units = 4, IsGE = true, GEEquivalent = "B5 or D4" },
                                new Course() { Number = "MAT 114", Title = "Analytic Geometry and Calculus I", Units = 4, IsGE = true, GEEquivalent = "B4" },
                            }
                        }
                    }
                };

                _context.Catalogs.Add(catalog);
                _context.Modules.AddRange(catalog.Modules);
            }

            await _context.SaveChangesAsync();  // push changes into database
        }

    }
}
