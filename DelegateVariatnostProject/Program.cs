namespace DelegateVariatnostProject
{
    class Car
    {
        
    }

    class Bmv : Car
    {

    }

    class Lexus : Car
    {

    }

    class Message
    {
        public string Text { set; get; }
        public Message(string text) => Text = text;
        public virtual void Show() => Console.WriteLine($"Message: {Text}");
    }

    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
        public override void Show() => Console.WriteLine($"Email: {Text}");

    }

    class SmsMessage : Message
    {
        public SmsMessage(string text) : base(text) { }
        public override void Show() => Console.WriteLine($"Sms: {Text}");

    }

    delegate Message MessageBuilder(string text);

    delegate void SmsReceiver(SmsMessage message);

    internal class Program
    {

        static SmsMessage SendSmsMessage(string text) => new SmsMessage(text);
        static EmailMessage WriteEmailMessage(string text) => new EmailMessage(text);
        static void ReceiverMessage(Message message) => message.Show();
        static void Main(string[] args)
        {
            MessageBuilder builder = WriteEmailMessage; //SendSmsMessage;

            Message message = builder("Hello world");

            message.Show();

            SmsReceiver receiver = ReceiverMessage;
            receiver(new SmsMessage("Hello people!"));

            //Car car = new Bmv();

            //List<Bmv> bmvs = new List<Bmv>();
            //List<Car> cars = bmvs;

            //IEnumerable<Bmv> bmvs = new List<Bmv>();
            //IEnumerable<Car> cars = bmvs;



        }
    }
}