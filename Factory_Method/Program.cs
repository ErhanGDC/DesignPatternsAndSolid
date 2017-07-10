using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Document[] documents = new Document[2];
            documents[0] = new Resume();
            documents[1] = new Report();

            //Display document pages
            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name.ToString());
                }
            }
            Console.ReadLine();
        }
    }
    abstract class Page { }
    class SkillsPage : Page { }
    class EducationPage : Page { }
    class ExperiencePage : Page { }
    class IntroductionPage : Page { }
    class ResultPage : Page { }
    class ConclusionPage : Page { }
    class SummaryPage : Page { }
    class BibliographyPage : Page { }
    abstract class Document
    {
        private List<Page> _pages = new List<Page>();
        public Document()
        {
            this.CreatePages();
        }
        public List<Page> Pages
        {
            get { return _pages; }
        }
        public abstract void CreatePages();
    }
    class Resume : Document
    {
        //Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }
    class Report : Document
    {

        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }
}
