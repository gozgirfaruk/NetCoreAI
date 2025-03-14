


using Google.Cloud.Vision.V1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Resim yolunu giriniz :");
        Console.WriteLine();
        string imagePath = Console.ReadLine();
        //google cloud üzerinden json dosyası indirilecek. Satır 40
        string credentialPath = "buraya servis json dosyası gelecek";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENIALS", credentialPath);

        try
        {
            var client = ImageAnnotatorClient.Create();

            var image = Image.FromFile(imagePath);
            var response = client.DetectText(image);
            Console.WriteLine("Resimdeki Metin : ");
            Console.WriteLine();
            foreach(var annotination in response)
            {
                if (!string.IsNullOrEmpty(annotination.Description))
                {
                    Console.WriteLine(annotination.Description);
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"Bir hata oluştu {e.Message}");
        }
    }
}

// TODO : Google Cloud Platform 

// 1. APIs & Services > Credentials sayfasına gidiniz
// 2. Create Credentials > Service Account seçeneğine tıklayınız
// 3. Sevice Accont Name kısmına bir isim veriniz.
// 4. Service Account ID otomatik olarak verilecektir.
// 5. Create and Continue düğmesine tıklayınız
// 6. Grant this service account access to project sayfasından   Select a role : Project > Owner seçiniz
// 7. Continue and Done seçeneklerine tıklanarak işlem tamamlanır.
// 8. Service Accounts alanında Menage service accounts seçeneğine tıklayınız
// 9. Servis hesabının yanındaki Üç Nokta tıklayınız ve Menage Keys'i seçin
// 10. Add Key > Create New Key seçeneğine tıklayınız.
// 11. Açılır pencereden JSON türünü seçin ve Create düğmesine basın
// 12. JSON türündeki dosya otomatik olarak bilgisayarınıza inecektir.

// : APIs Servislerinin Etkinleştirilmesi

// 1. Enabled APIs & Services  
// 2. Cloud Vision API > enable seçiniz.