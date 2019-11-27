    using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace StaffDatabase.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StaffDatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StaffDatabaseContext>>()))
            {
                // If there are already entries in DB no need to seed
                if (context.StaffMember.Any())
                {
                    return;   // DB has been seeded
                }

                context.StaffMember.AddRange(
                    new StaffMember
                    {
                        Fname = "Liam",
                        Lname = "Royal",
                        Mname = "J",
                        HomePh = 5766210,
                        CellPh = 0278668096,
                        OffExtension = 21,
                        IrdNo = 7786689,
                        Status = false

                    },

                    new StaffMember
                    {
                        Fname = "Chris",
                        Lname = "Moon",
                        Mname = "K",
                        HomePh = 5734191,
                        CellPh = 021615545,
                        OffExtension = 21,
                        IrdNo = 7876621,
                        Status = true
                    },

                    new StaffMember
                    {
                        Fname = "Marcus",
                        Lname = "Morris",
                        Mname = "J",
                        HomePh = 5398882,
                        CellPh = 027485921,
                        OffExtension = 23,
                        IrdNo = 8290021,
                        Status = false
                    },

                    new StaffMember
                    {
                        Fname = "Markeef",
                        Lname = "Burke",
                        Mname = "B",
                        HomePh = 5490821,
                        CellPh = 021888921,
                        OffExtension = 22,
                        IrdNo = 4312313,
                        Status = false
                    },

                    new StaffMember
                    {
                        Fname = "LeBron",
                        Lname = "Royal",
                        Mname = "J",
                        HomePh = 5766210,
                        CellPh = 0278668096,
                        OffExtension = 21,
                        IrdNo = 6586689,
                        Status = false

                    },

                    new StaffMember
                    {
                        Fname = "Xavier",
                        Lname = "Moon",
                        Mname = "K",
                        HomePh = 5734191,
                        CellPh = 021615545,
                        OffExtension = 21,
                        IrdNo = 8876621,
                        Status = true
                    },

                    new StaffMember
                    {
                        Fname = "Jeff",
                        Lname = "Morris",
                        Mname = "J",
                        HomePh = 5398882,
                        CellPh = 027485921,
                        OffExtension = 23,
                        IrdNo = 4390021,
                        Status = true
                    },

                    new StaffMember
                    {
                        Fname = "Carlos",
                        Lname = "Burke",
                        Mname = "B",
                        HomePh = 5490821,
                        CellPh = 021888921,
                        OffExtension = 22,
                        IrdNo = 3212313,
                        Status = false
                    },

                    new StaffMember
                    {
                        Fname = "Lynda",
                        Lname = "Royal",
                        Mname = "J",
                        HomePh = 5766210,
                        CellPh = 0278668096,
                        OffExtension = 21,
                        IrdNo = 32186689,
                        Status = false

                    },

                    new StaffMember
                    {
                        Fname = "John",
                        Lname = "Moon",
                        Mname = "K",
                        HomePh = 5734191,
                        CellPh = 021615545,
                        OffExtension = 21,
                        IrdNo = 1276621,
                        Status = true
                    },

                    new StaffMember
                    {
                        Fname = "Mark",
                        Lname = "Morris",
                        Mname = "J",
                        HomePh = 5398882,
                        CellPh = 027485921,
                        OffExtension = 23,
                        IrdNo = 8990021,
                        Status = false
                    },

                    new StaffMember
                    {
                        Fname = "Dorris",
                        Lname = "Burke",
                        Mname = "B",
                        HomePh = 5490821,
                        CellPh = 021888921,
                        OffExtension = 22,
                        IrdNo = 882313,
                        Status = true
                    },

                    new StaffMember
                    {
                        Fname = "Nathan",
                        Lname = "Tony",
                        Mname = "B",
                        HomePh = 5490821,
                        CellPh = 021888921,
                        OffExtension = 22,
                        IrdNo = 5182313,
                        Status = false
                    },

                    new StaffMember
                    {
                        Fname = "Pamela",
                        Lname = "Klow",
                        Mname = "C",
                        HomePh = 5490821,
                        CellPh = 021888921,
                        OffExtension = 22,
                        IrdNo = 843313,
                        Status = true
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
