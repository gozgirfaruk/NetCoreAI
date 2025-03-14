

using Tesseract;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Karakter okuması yapılacak resim yolu :");
        string imagePath = Console.ReadLine();
        Console.WriteLine();

        string tessDataPath = @"C:\tessdata";

        try
        {
            // TesseractEngine : OCR motorunu başlatır.
            using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
            {
                // Pix : tesseract için resimleri işlenebilir hale getirir.
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        string text = page.GetText();
                        Console.WriteLine("Okunan metin");
                        Console.WriteLine(text);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Bir hata meydana geldi : {e.Message}");
        }
        Console.ReadLine();
    }
}