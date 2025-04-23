// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Document
{
}

public interface IMachine
{
    void Print(Document d);
    void Scan(Document d);
    void Fax(Document d);
}

public class MultiFunctionPrinter : IMachine
{
    public void Print(Document d)
    {
        //
    }

    public void Scan(Document d)
    {
        //
    }

    public void Fax(Document d)
    {
        //
    }
}

public class OldFashionedPrinter :IMachine
{
    public void Print(Document d)
    {
        throw new NotImplementedException();
    }

    public void Scan(Document d)
    {
        throw new NotImplementedException();
    }

    public void Fax(Document d)
    {
        throw new NotImplementedException();
    }
}

public interface IPrinter
{
    void Print(Document document);
}

public interface IScanner
{
    void Scan(Document document);
}

public interface IFax
{
    void Fax(Document document);
}
public class Photocopier :IPrinter,IScanner
{
    public void Print(Document document)
    {
        throw new NotImplementedException();
    }

    public void Scan(Document document)
    {
        throw new NotImplementedException();
    }
}

public interface IMultiFunctionDevice :IScanner,IPrinter //.....
{
    
}
public class MultiFunctionDevice :IMultiFunctionDevice
{
    private readonly IPrinter _printer;
    private readonly IScanner _scanner;

    public MultiFunctionDevice(IPrinter printer,IScanner scanner)
    {
        _printer = printer;
        _scanner = scanner;
    }
    public void Scan(Document document)
    {
        _scanner.Scan(document);
    }

    public void Print(Document document)
    {
        _printer.Print(document);
    }
}
/*
 * Interface Segregation Principle (ISP):
 *
 * Bir sınıf, kullanmadığı arayüzleri implement etmemelidir. Yani, büyük ve karmaşık arayüzler yerine daha küçük ve spesifik arayüzler tercih edilmelidir.
 * Uçmak zorunda olmayan bir çalışana `IFlyable` arayüzü eklemek yerine, sadece ihtiyaç duyduğu `IWorker` arayüzünü implement ederiz.
 */