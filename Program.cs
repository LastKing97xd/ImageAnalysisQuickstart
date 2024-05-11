using Azure;
using Azure.AI.Vision.ImageAnalysis;
using System;

public class Program
{
    static void AnalyzeImage()
    {
        string endpoint = "https://axs-pruebaocr.cognitiveservices.azure.com/";
        string key = "e6f144686897421db8eb396dd61152a7";

        ImageAnalysisClient client = new ImageAnalysisClient(
            new Uri(endpoint),
            new AzureKeyCredential(key));

        ImageAnalysisResult result = client.Analyze(
            //new Uri("https://t1.uc.ltmcdn.com/es/posts/3/4/9/las_mejores_frases_de_amor_para_mi_novia_46943_orig.jpg"),
            new Uri("https://tienda.serviciodirecto.cl/wp-content/uploads/2020/08/boleta.png"),
            //VisualFeatures.Caption | 
            VisualFeatures.Read,
            new ImageAnalysisOptions { GenderNeutralCaption = true });

        Console.WriteLine("Image analysis results:");
        //Console.WriteLine(" Caption:");
        //Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");

        Console.WriteLine(" Read:");
        foreach (DetectedTextBlock block in result.Read.Blocks)
            foreach (DetectedTextLine line in block.Lines)
            {
                Console.WriteLine($"   Line: '{line.Text}'");
                foreach (DetectedTextWord word in line.Words)
                {
                    Console.WriteLine($"     Word: '{word.Text}'");
                }
            }

        //foreach (DetectedTextBlock block in result.Read.Blocks)
        //    foreach (DetectedTextLine line in block.Lines)
        //    {
        //        Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
        //        foreach (DetectedTextWord word in line.Words)
        //        {
        //            Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
        //        }
        //    }
    }

    static void Main()
    {
        try
        {
            AnalyzeImage();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}