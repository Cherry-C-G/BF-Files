namespace SOLID_InterfaceSegregationPrinciple
{
    /// <summary>
    /// Your interfaces should be segregated, so the clients who implement
    /// your interfaces haven't need to implement the functions they don't need.
    /// </summary>
    public class Document { }

    public interface IMultiFuncPrinter
    {
        void Print (Document document);
        void Scan (Document document);
        void Fax (Document document);
    }

    public class NewMachine : IMultiFuncPrinter
    {
        public void Fax(Document document)
        {
            // implementation
        }

        public void Print(Document document)
        {
            // implementation
        }

        public void Scan(Document document)
        {
            // implementation
        }
    }
    // what if this OldMachine can only print something
    // this big interface force the OldMachine to implement more functions
    // that violates ISP. What can you do in this situation?
    public class OldMachine : IMultiFuncPrinter
    {
        public void Fax(Document document)
        {
            Console.WriteLine("Not Supported");
        }

        public void Print(Document document)
        {
            // implementation
        }

        public void Scan(Document document)
        {
            Console.WriteLine("Not Supported");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}