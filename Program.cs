using System;
using System.Threading;

namespace Events_Continue
{
    public delegate void ProgressChangedHandler(int percent,int changedValue);
    public delegate void MyDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            // Now to subscribe the methods to the event
      
         
            ProgressBar progresssBar = new ProgressBar(30); 
  
            progresssBar.Progress = 30;
             Thread.Sleep(4000);
            progresssBar.ProgressChanged += OnProgressChanged;
            progresssBar.ProgressChanged += OnProgressChanged1;

            progresssBar.Progress = 30;
            progresssBar.Progress = 60;
              
              progresssBar.TheNotifier();
            Thread.Sleep(4000);
            progresssBar.OnMyDelegate += OnMyDelegateMethod;
            progresssBar.OnMyDelegate += OnMyDelegateMethod1;
            // progresssBar.Progress;
        }
        public static void OnProgressChanged(int percent,int changedValue)
        {
            // System.Console.WriteLine("OnProgressChanged() event");
            System.Console.WriteLine("Progressed from {0} to {1} ",percent,changedValue);
            System.Console.WriteLine("Message Sent");
        }


        public static void OnMyDelegateMethod()
        {
            System.Console.WriteLine("This is the OnMyDelegate Method 1");
        }
        public static void OnMyDelegateMethod1()
        {
             System.Console.WriteLine("This is the OnMyDelegate Method 2");
        }
        public static void OnProgressChanged1(int percent1,int changedValue1)
        {
            // System.Console.WriteLine("OnProgessChanged() event");
            System.Console.WriteLine("Progressed From {0} to {1}",percent1,changedValue1);
              System.Console.WriteLine("Message Sent");
        }
       
    }
    class ProgressBar
    {
            int percent;
            int oldPercent;
            public ProgressBar(int _percent)
            {
                  percent = _percent;
                  Console.WriteLine("The _percent is {0}",_percent);
                  System.Console.WriteLine("We are Sending A message To your Subscribers");
            }
        public event ProgressChangedHandler ProgressChanged;
        public event MyDelegate OnMyDelegate;
        public static void D()
        {
        }
        public int Progress 
        {
          get {return percent;}
          set 
          {
                if(percent == value)
                return;
                if (ProgressChanged != null)
                ProgressChanged(percent,value);
                oldPercent = percent;
                percent = value;
                if(OnMyDelegate != null )
               OnMyDelegate();
          }
        }
         public  void TheNotifier()
        {
            System.Console.WriteLine("This is the Notifier. I Am notifying Your Methods......");
        }
        
    }
}
