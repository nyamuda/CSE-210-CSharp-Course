using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Microsoft", "Software Developer", "2019", "2021");
        Job job2 = new Job("Apple", "Data Scientist", "2021", "2022");

        Resume person1 = new Resume("Tatenda Nyamuda");

        //add the jobs to person1
        person1.setJobs(job1);
        person1.setJobs(job2);

        //display the resume
        person1.DisplayResume();


    }
}



