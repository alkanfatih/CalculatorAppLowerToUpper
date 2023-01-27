// Uygulama Adını Göster
Console.WriteLine("Basit Bir C# Hesap Makinası");
Console.WriteLine("İşlem Seçiniz: [ + | - | * | / ] Çıkış yapmak için boş geçiniz.");

// Değişkenleri Tanımla
double firstNum, secondNum, result = 0;
string mathOp;

// Kullanıcıdan veri al ve Tip Dönüşümü
Console.Write("Sayı 1: ");
firstNum = Convert.ToDouble(Console.ReadLine());

Console.Write("Sayı 2: ");
secondNum = Convert.ToDouble(Console.ReadLine());

Console.Write("İşlem: ");
mathOp = Console.ReadLine();

//Kullanicinın çıkış yapıp yapmadığını kontrol et.
if (mathOp != string.Empty)
{
    // Kullanıcının hangi işlemi girdiğini belirleme
    switch (mathOp)
    {
        // Kullaniciya işleme göre sonucu göster.
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
            break;
    }
}
else
{
    Console.WriteLine("İşlem yapılamadı.");
}