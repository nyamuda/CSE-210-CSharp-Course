using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int grade=int.Parse(Console.ReadLine());
        string letter="";
        string message="Congratulations, you passed the class.";

        if(grade>=93) {
            letter="A";
        }
        else if(grade>=90) {
             letter="A-";
        }
        else if(grade>=87) {
             letter="B+";
        }
        else if(grade>=83) {
             letter="B";
        }
        else if(grade>=80) {
             letter="B-";
        }
        else if(grade>=77) {
             letter="C+";
        }
        else if(grade>=73) {
             letter="C";
        }
        else if(grade>=70) {
             letter="C-";
        }
        else if(grade>=67) {
             letter="D+";
             message="Sorry, you failed the class.";
        }
        else if(grade>=63) {
             letter="D";
              message="Sorry, you failed the class.";
        }
        else if(grade>=60) {
             letter="D-";
              message="Sorry, you failed the class.";
        }
        else {
             letter="F";
              message="Sorry, you failed the class.";
        }

        Console.WriteLine($"Your grade letter is {letter}. {message}");
    }
}