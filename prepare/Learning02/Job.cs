using System;


public class Job
{
    private string _company;
    private string _jobTitle;
    private string _startYear;
    private string _endYear;

    public Job(string company, string jobTitle, string startYear, string endYear)
    {
        this._company = company;
        this._jobTitle = jobTitle;
        this._startYear = startYear;
        this._endYear = endYear;
    }

    public string DisplayJobDetails()
    {
        string jobInfo = $"{this._jobTitle} ({this._jobTitle}) {this._startYear}-{this._endYear}";
        return jobInfo;
    }

}