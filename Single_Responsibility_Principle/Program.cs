using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            IContent content = new setContent("This is a message");
            Email newPost = new Email();
            newPost.setSender("From Erhan");
            newPost.setReciver("To Someone");
            newPost.setContent(content);

            EmailSender sender = new EmailSender();
            sender.Send(newPost);

            Console.ReadLine();
        }
    }
    public interface IEmail
    {
        IContent content { get; }
        string sender { get; }
        string reciver { get; }
        void setSender(string sender);
        void setReciver(string reciver);
        void setContent(IContent content);
    }
    public interface IContent
    {
        string content { get; }
        string getAsString(string content);//used for serialization
    }
    public class Email : IEmail
    {
        public Email()
        {
            Console.WriteLine("Constractor Called\n\n\n");
        }
        public void setSender(string _sender)
        {
            this.sender = _sender;
        }
        public void setReciver(string _reciver)
        {
            this.reciver = _reciver;
        }
        public void setContent(IContent _content)
        {
            this.content = _content;
        }
        public IContent content
        {
            get;
            set;
        }

        public string sender
        {
            get;
            private set;
        }

        public string reciver
        {
            get;
            private set;
        }
    }

    public class setContent : IContent
    {
        public string content { get; private set; }
        public setContent(string _message)
        {
            this.content = getAsString(_message);
        }
        public string getAsString(string _content)
        {
            //Assume as serialization done..
            return this.content = _content;
        }
    }

    public abstract class EmailSenderAbstract
    {
        public abstract void Send(IEmail email);
    }
    public class EmailSender : EmailSenderAbstract
    {
        public override void Send(IEmail email)
        {
            Console.WriteLine(string.Format("Sender:{0}", email.sender));
            Console.WriteLine(string.Format("Receiver:{0}", email.reciver));
            Console.WriteLine(string.Format("Content:{0}", email.content.content));
        }
    }
}
