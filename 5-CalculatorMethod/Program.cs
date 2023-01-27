// Uygulama Adını Göster
Console.WriteLine("C# Hesap Makinası Programı");
Console.WriteLine("İşlem Seçiniz: [ + | - | * | / ] çıkmak için boşluk tuşuna basınız");

// İşlemi yapan metodu çağır.
Calculate();

//Void belirli bir görevi yapan metot oluştur.
static void Calculate()
{
    // Hesap Makinesi için ihtiyacımız olan değişkenleri bildirin
    double firstNum, secondNum, result = 0;
    string mathOp = "+";
    string[] ValidMathOperators = { "+", "-", "*", "/" };

    // Döngüden önceki ilk sayıyı al
    Console.Write("Sayı 1: ");
    firstNum = Convert.ToDouble(Console.ReadLine());
    while (mathOp != String.Empty)
    {
        try
        {

            // Kullancidan İşlemi Al
            Console.Write("İşlem: ");
            mathOp = Console.ReadLine();

            // kullanıcı tarafından girilen matematik operatörünün geçerli olup olmadığını kontrol edin; değilse döngüden çıkış yapın.

            if (!Array.Exists(ValidMathOperators, e => e == mathOp))
            {
                Console.WriteLine("Geçersiz İşlem");
                mathOp = String.Empty;
                continue;
            }
            // Denklemin ilk kısmını yazdırın.
            Console.Write("{0} {1} ", firstNum, mathOp);

            // Kullanicidan ikinci sayıyı alın
            secondNum = Convert.ToDouble(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Hesaplama Gerçekleşmedi!");
            mathOp = String.Empty;
            continue;
        }

        // Hesaplama İşlemi
        switch (mathOp)
        {
            //İşlem tipine göre parametreli metot çağır.
            case "+":
                Console.WriteLine("Toplam: {0}", result = GetSum(firstNum, secondNum));
                break;
            case "-":
                Console.WriteLine("Fark: {0}", result = GetSubtract(firstNum, secondNum));
                break;
            case "*":
                Console.WriteLine("Çarpım: {0}", result = GetMultiple(firstNum, secondNum));
                break;
            case "/":
                Console.WriteLine("Bölüm: {0}", result = GetDivision(firstNum, secondNum));
                break;
            default:
                mathOp = String.Empty;
                continue;
        }
        // Kullaniciya sonucu göster
        Console.WriteLine(" = {0}", result);

        // Tekrar döngüye girmeden önce sonucu firstNum'a atayın
        firstNum = result;
    }
}
//Geri değer döndüren parametreli metot oluştur.
static double GetDivision(double firstNum, double secondNum)
{
    return firstNum / secondNum;
}
static double GetMultiple(double firstNum, double secondNum)
{
    return firstNum * secondNum;
}
static double GetSubtract(double firstNum, double secondNum)
{
    return firstNum - secondNum;
}
static double GetSum(double firstNum, double secondNum)
{
    return firstNum + secondNum;
}
