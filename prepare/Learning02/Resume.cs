using System;

public class Resume
{
    private string _name;
    private List<Job> _jobs = new List<Job>();


    public Resume(string name)
    {
        this._name = name;
    }

    public void setJobs(Job job)
    {
        this._jobs.Add(job);
    }

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {this._name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {

            Console.WriteLine(job.DisplayJobDetails());
        }

    }
}