using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        string inputFile = "data.txt";
        string outputFile = "output.txt";

        try
        {
            string text = "";
            int lineCount = 0;
            int wordCount = 0;

            using (StreamReader reader = new StreamReader(inputFile))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    text += line + "\n"; // Include newline if needed
                    lineCount++;
                    wordCount += line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                writer.WriteLine($"No of lines      : {lineCount}");
                writer.WriteLine($"No of characters : {text.Length}");
                writer.WriteLine($"No of words      : {wordCount}");
                writer.WriteLine($"No of 'e' chars  : {CountChar(text, 'e')}");
            }

            Console.WriteLine("Processing complete. Results written to output.txt.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: File not found - {ex.FileName}");
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O error occurred: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

    static int CountChar(string source, char ch)
    {
        int count = 0;
        foreach (char c in source)
        {
            if (c == ch) count++;
        }
        return count;
    }
}
