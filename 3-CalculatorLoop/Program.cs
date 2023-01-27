// Uygulama Adını Göster
Console.WriteLine("Basit Bir C# Hesap Makinası");
Console.WriteLine("İşlem Seçiniz: [ + | - | * | / ]");

// Değişkenleri Tanımla
double firstNum, secondNum, result = 0;
string mathOp = "+";

// Kullanıcıdan veri al ve Tip Dönüşümü
Console.Write("Sayı 1: ");
firstNum = Convert.ToDouble(Console.ReadLine());

while (mathOp != String.Empty)
{
    try
    {
        // Kullanicidan İşlemi Al
        Console.Write("İşlem: ");
        mathOp = Console.ReadLine();

        // Sayı1 ve İşlemi Yaz
        Console.Write("{0} {1} ", firstNum, mathOp);

        // Kullanıcıdan Sayı 2 al ve Tip Dönüşümü
        secondNum = Convert.ToDouble(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("İşlem Yapılamadı!");
        mathOp = String.Empty;
        continue;
    }
    // Kullanıcının hangi işlemi girdiğini belirleme
    switch (mathOp)
    {
        case "+":
            result = firstNum + secondNum;
            Console.WriteLine("Toplamı: {0}", result);
            break;
        case "-":
            result = firstNum - secondNum;
            Console.WriteLine("Çıkarma: {0}", result);
            break;
        case "*":
            result = firstNum * secondNum;
            Console.WriteLine("Çarpımı: {0}", result);
            break;
        case "/":
            result = firstNum / secondNum;
            Console.WriteLine("Bölümü: {0}", result);
            break;
        default:
            mathOp = String.Empty;
            continue;
    }
    // Kullaniciya sonucu göster.
    Console.WriteLine(" = {0}", result);

    // İşlemin devamlı olması için tekrar döngüye girmeden önce sonucu firstNum'a atayın
    firstNum = result;
}
Console.WriteLine("Answer: {0}", result);