internal class Program
{
    private static void Main(string[] args)
    {
        ConsoleCalculator calc = new ConsoleCalculator();
        calc.On();
        calc.GetFirstNumber();
        while (calc.ContinueCalculating)
        {
            calc.GetMathOperator();
            calc.GetSecondNumber();
            calc.Calculate();
        }
        calc.Off();
    }
}

//ConsoleCalculator, temel sınıfı olan Calculator'dan miras alır.
class ConsoleCalculator : Calculator
{
    public void On()
    {
        // Uygulama Adını Göster
        Console.WriteLine("C# Hesap Makinası Programı");
        Console.WriteLine("İşlem Seçiniz: [ + | - | * | / ] çıkmak için boşluk tuşuna basınız");
    }
    public void Off()
    {
        Console.WriteLine("Result: {0}", Result);
    }
    public void GetFirstNumber()
    {
        // Döngüden önceki ilk sayıyı al
        Console.Write("Sayı 1: ");
    }
    public void GetMathOperator()
    {
        // Kullanicidan işlemi alınız.
        Console.Write("[ + | - | * | /  ] : ");
        MathOp = Console.ReadLine();
    }
    public void GetSecondNumber()
    {
        // Kullanicidan ikinci sayıyı alınız
        Console.Write("{0} {1} ", FirstNum, MathOp);
        SetNumber(Console.ReadLine());
    }
    public void Calculate()
    {
        if (ContinueCalculating)
        {
            // Sonucu Hesapla
            base.Calculate();
            // Kullaniciya Sonucu Göster
            Console.WriteLine(" = {0}", Result);
        }
    }
}
// --- Calculator Class --- 
// Yeni bir değişiklik yok bir önceki konuyla aynı

class Calculator
{
    // Field tanımlayın
    private string[] validMathOperators = { "+", "-", "*", "/" };
    private string prevMathOp, mathOp;
    private bool firstNumber;

    // Properties tanımlayın
    public bool ContinueCalculating { get; private set; }
    public double FirstNum { get; private set; }
    public double SecondNum { get; private set; }
    public double Result { get; private set; }
    public string MathOp
    {
        get { return mathOp; }
        set
        {
            if (Array.Exists(validMathOperators, el => el == value))
            {
                mathOp = value;
            }
            else
            {
                mathOp = prevMathOp;
            }
        }
    }
    // Constructor (Yapıcı Metot) tanımlayın.
    public Calculator()
    {
        // Calculator Nesnesi oluşturulduğunda Propertiesleri ve Değişkenleri Başlat
        prevMathOp = validMathOperators[0];
        firstNumber = true;
        ContinueCalculating = true;
    }
    // public Method tanımlayın
    public void SetNumber(string input)
    {
        double number;
        try
        {
            number = Convert.ToDouble(input);
        }
        catch
        {
            number = 0;
            ContinueCalculating = false;
        }
        if (firstNumber)
        {
            FirstNum = number;
            firstNumber = false;
        }
        else
        {
            SecondNum = number;
        }
    }
    public void Calculate()
    {
        // İşlemleri gerçekleştirin.
        switch (MathOp)
        {
            case "+":
                Result = FirstNum + SecondNum;
                break;
            case "-":
                Result = FirstNum - SecondNum;
                break;
            case "*":
                Result = FirstNum * SecondNum;
                break;
            case "/":
                Result = FirstNum / SecondNum;
                break;
            default:
                break;
        }

        //Bir önceki sayıdan hesaplamaya devam ediyoruz...
        FirstNum = Result;

        //Kullanıcı boş bırakırsa, matematik operatörünün varsayılan olarak önceki değerine dönmesini istiyoruz...
        prevMathOp = MathOp;
    }
}