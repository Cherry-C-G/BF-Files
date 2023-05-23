namespace SingletonDesignPattern
{
    /// <summary>
    /// Singleton: Only one instatnce object can exist at a time 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //simple singleton
            SingletonClass singletonClass = SingletonClass.GetInstance();
            //thread-safe singleton
            Singleton singleton = Singleton.GetInstance(); 
        }
    }

    //How to create a simple singleton class
    public class SingletonClass
    {
        //Step3: ensure only one Instance exists at the same time
        private static SingletonClass _instance;

        //Step1: set the constructor private
        //ensure other people cannot use new keyword to create instance object
        private SingletonClass () { }

        //Step2: Define static method to instantiate objects
        //then store the instance to Instance field.
        public static SingletonClass GetInstance()
        {
            if (_instance == null)
            {
                _instance= new SingletonClass ();
            }

            return _instance;
        }
    }

    //The simple singleton cannot work in multi-threading environment
    //We recommand to use:
    //Double-check thread-safe Singleton class
    public class Singleton
    {
        //use this insatnce to check only one instance is allowed
        private static Singleton _instance;
        //create an object type to perform lock
        private static readonly object _instanceLock = new object ();
        //private constructor to prevent instantiation from outside
        private Singleton () { }

        public static Singleton GetInstance()
        {
            if ( _instance == null )
            {
                lock(_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton ();
                    }
                }
            }
            return _instance;
        }
    }
}