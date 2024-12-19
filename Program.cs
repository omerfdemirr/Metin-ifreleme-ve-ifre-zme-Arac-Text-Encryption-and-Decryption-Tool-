using System;
using System.Text;

namespace MetinSifrelemeAraci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Metin Şifreleme ve Şifre Çözme Uygulamasına Hoş Geldiniz!");
            Console.WriteLine("--------------------------------------------------------");

            while (true)
            {
                Console.WriteLine("\nSeçenekler:");
                Console.WriteLine("1. Metin Şifrele");
                Console.WriteLine("2. Şifre Çöz");
                Console.WriteLine("3. Çıkış");

                Console.Write("Lütfen bir seçenek seçin (1/2/3): ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        MetinSifrele();
                        break;
                    case "2":
                        SifreCoz();
                        break;
                    case "3":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        static void MetinSifrele()
        {
            Console.Write("Şifrelemek istediğiniz metni girin: ");
            string metin = Console.ReadLine();

            Console.WriteLine("\nŞifreleme Yöntemleri:");
            Console.WriteLine("1. Basit Kaydırma Şifreleme (Caesar Cipher)");
            Console.WriteLine("2. ASCII Tabanlı Şifreleme");
            Console.Write("Bir yöntem seçin (1/2): ");
            string yontem = Console.ReadLine();

            string sifreliMetin = yontem switch
            {
                "1" => CaesarSifrele(metin),
                "2" => ASCIISifrele(metin),
                _ => "Geçersiz şifreleme yöntemi seçildi."
            };

            Console.WriteLine($"\nŞifreli Metin: {sifreliMetin}");
        }

        static void SifreCoz()
        {
            Console.Write("Şifre çözmek istediğiniz metni girin: ");
            string sifreliMetin = Console.ReadLine();

            Console.WriteLine("\nŞifre Çözme Yöntemleri:");
            Console.WriteLine("1. Basit Kaydırma Şifre Çözme (Caesar Cipher)");
            Console.WriteLine("2. ASCII Tabanlı Şifre Çözme");
            Console.Write("Bir yöntem seçin (1/2): ");
            string yontem = Console.ReadLine();

            string cozulmusMetin = yontem switch
            {
                "1" => CaesarSifreCoz(sifreliMetin),
                "2" => ASCIICoz(sifreliMetin),
                _ => "Geçersiz şifre çözme yöntemi seçildi."
            };

            Console.WriteLine($"\nÇözülmüş Metin: {cozulmusMetin}");
        }

        static string CaesarSifrele(string metin)
        {
            int kaydirma = 3;
            StringBuilder sifreliMetin = new StringBuilder();

            foreach (char karakter in metin)
            {
                if (char.IsLetter(karakter))
                {
                    char ilkHarf = char.IsUpper(karakter) ? 'A' : 'a';
                    char sifreliKarakter = (char)((karakter + kaydirma - ilkHarf) % 26 + ilkHarf);
                    sifreliMetin.Append(sifreliKarakter);
                }
                else
                {
                    sifreliMetin.Append(karakter);
                }
            }

            return sifreliMetin.ToString();
        }

        static string CaesarSifreCoz(string sifreliMetin)
        {
            int kaydirma = 3;
            StringBuilder cozulmusMetin = new StringBuilder();

            foreach (char karakter in sifreliMetin)
            {
                if (char.IsLetter(karakter))
                {
                    char ilkHarf = char.IsUpper(karakter) ? 'A' : 'a';
                    char cozulmusKarakter = (char)((karakter - kaydirma - ilkHarf + 26) % 26 + ilkHarf);
                    cozulmusMetin.Append(cozulmusKarakter);
                }
                else
                {
                    cozulmusMetin.Append(karakter);
                }
            }

            return cozulmusMetin.ToString();
        }

        static string ASCIISifrele(string metin)
        {
            StringBuilder sifreliMetin = new StringBuilder();

            foreach (char karakter in metin)
            {
                int asciiDegeri = karakter + 5; // ASCII değerini 5 artır
                sifreliMetin.Append((char)asciiDegeri);
            }

            return sifreliMetin.ToString();
        }

        static string ASCIICoz(string sifreliMetin)
        {
            StringBuilder cozulmusMetin = new StringBuilder();

            foreach (char karakter in sifreliMetin)
            {
                int asciiDegeri = karakter - 5; // ASCII değerini 5 azalt
                cozulmusMetin.Append((char)asciiDegeri);
            }

            return cozulmusMetin.ToString();
        }
    }
}
