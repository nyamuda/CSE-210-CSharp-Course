public class Math
{

    public int _number1;

    public int _number2;

    public Math(int number1, int number2)
    {
        this._number1 = number1;
        this._number2 = number2;
    }

    public virtual int calculate()
    {

    }
}


public class Add : Math
{
    public Add(int number1, int number2) : base(number1, number2);


    public override int calculate()
    {
        return this._number1 + this._number2;
    }


}

public class Multiply : Math
{
    public Multiply(int number1, int number2) : base(number1, number2);


    public override int calculate()
    {
        return this._number1 * this._number2;
    }


}



