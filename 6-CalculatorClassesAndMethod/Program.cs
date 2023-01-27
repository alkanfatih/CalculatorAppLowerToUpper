internal class Program
{
    private static void Main(string[] args)
    {
        // Uygulama Adını Göster
        Console.WriteLine("C# Hesap Makinası Programı");
        Console.WriteLine("İşlem Seçiniz: [ + | - | * | / ] çıkmak için boşluk tuşuna basınız");

        //Oluşturduğumuz Sınıfı çağır.
        Calculator calc = new Calculator();
        // Döngüden önceki ilk sayıyı al
        Console.Write("Sayı 1: ");
        calc.SetNumber(Console.ReadLine());
        while (calc.ContinueCalculating)
        {

            // Kullanicidan işlemi alınız.
            Console.Write("[ + | - | * | /  ] : ");
            calc.MathOp = Console.ReadLine();
            // Kullanicidan ikinci sayıyı alınız
            Console.Write("{0} {1} ", calc.FirstNum, calc.MathOp);
            calc.SetNumber(Console.ReadLine());
            if (calc.ContinueCalculating)
            {
                // Sonucu hesaplayın
                calc.Calculate();
                // Sonucu Gösterin
                Console.WriteLine(" = {0}", calc.Result);
            }
        }
        Console.WriteLine("Result: {0}", calc.Result);
    }
}
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