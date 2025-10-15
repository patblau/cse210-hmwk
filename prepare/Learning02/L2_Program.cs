using System;
using System.Collections.Generic;
using Learning02;

class L2_Program
{
    static void Main(string[] args)
    {
        // job = with company, title, start yr, end yr
        Job job1 = new Job();
        job1._company = "McDonalds";
        job1._jobTitle = "Crew";
        job1._startYear = 1988;
        job1._endYear = 1990;

        Job job2 = new Job();
        job2._company = "Emery Chiropractic Center";
        job2._jobTitle = "Massage Therapist";
        job2._startYear = 1991;
        job2._endYear = 1993;

        Job job3 = new Job();
        job3._company = "Miller Freeman Publishing";
        job3._jobTitle = "Warehouse Manager";
        job3._startYear = 1998;
        job3._endYear = 2008;

        Job job4 = new Job();
        job4._company = "Digital Dynamics Technology";
        job4._jobTitle = "Customer Service Technician";
        job4._startYear = 2008;
        job4._endYear = 2018;

        Job job5 = new Job();
        job5._company = "Human Potential Services";
        job5._jobTitle = "Janitor";
        job5._startYear = 2016;
        job5._endYear = 2020;

        Job job6 = new Job();
        job6._company = "Lawrence Memorial Hospital";
        job6._jobTitle = "Janitor";
        job6._startYear = 2018;
        job6._endYear = 2020;

        Job job7 = new Job();
        job7._company = "1AssistCare";
        job7._jobTitle = "Home Care Assistant";
        job7._startYear = 2020;
        job7._endYear = 2022;

        Job job8 = new Job();
        job8._company = "Lap Lanes LLC";
        job8._jobTitle = "Home Care Assistant";
        job8._startYear = 2020;
        job8._endYear = 2025;

        Job job9 = new Job();
        job9._company = "BYUI";
        job9._jobTitle = "Student";
        job9._startYear = 2017;
        job9._endYear = 2025;

        // Build and display the resume
        Resume resume = new Resume { _name = "Pat Blau" };
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume._jobs.Add(job3);
        resume._jobs.Add(job4);
        resume._jobs.Add(job5);
        resume._jobs.Add(job6);
        resume._jobs.Add(job7);
        resume._jobs.Add(job8);
        resume._jobs.Add(job9);

        resume.Display();  // <-- prints 

    }
}