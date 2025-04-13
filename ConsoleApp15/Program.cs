using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    public interface ITextFormatter
    {
        string Format(string text);
    }

   
    public class UpperCaseFormatter : ITextFormatter
    {
        public string Format(string text)
        {
            return text.ToUpper();
        }
    }

    
    public class LowerCaseFormatter : ITextFormatter
    {
        public string Format(string text)
        {
            return text.ToLower();
        }
    }

    
    public class TitleCaseFormatter : ITextFormatter
    {
        public string Format(string text)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(text);
        }
    }

    
    public class TextEditor
    {
        private ITextFormatter formatter;

        public TextEditor(ITextFormatter formatter)
        {
            this.formatter = formatter;
        }

       
        public void SetFormatter(ITextFormatter formatter)
        {
            this.formatter = formatter;
        }

       
        public string FormatText(string text)
        {
            return formatter.Format(text);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            
            ITextFormatter upperCase = new UpperCaseFormatter();
            ITextFormatter lowerCase = new LowerCaseFormatter();
            ITextFormatter titleCase = new TitleCaseFormatter();

            TextEditor editor = new TextEditor(upperCase);
            Console.WriteLine($"Форматування у верхній регістр: {editor.FormatText("hello world")}"); 

            
            editor.SetFormatter(titleCase);
            Console.WriteLine($"Форматування у заголовний регістр: {editor.FormatText("hello world")}"); 

            
            editor.SetFormatter(lowerCase);
            Console.WriteLine($"Форматування у нижній регістр: {editor.FormatText("HELLO WORLD")}"); 
        }
    }
}
