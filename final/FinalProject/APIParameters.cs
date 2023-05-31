public class APIParameters
{
    private string appid;
    private string input;
    private string output;

    public APIParameters(string input)
    {
        this.appid = "KH9XP6-GETKE95TK6";
        this.input = input;
        this.output = "json";
    }


    public string GetParameters()
    {
        return $"appid={this.appid}&input={this.input}&output={this.output}";
    }
}