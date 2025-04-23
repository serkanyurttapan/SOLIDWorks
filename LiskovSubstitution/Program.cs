// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");


public class Rectangle
{
    public virtual int Widht { get; set; }
    public virtual int Height { get; set; }

    public Rectangle()
    {
    }

    public Rectangle(int widht, int height)
    {
        Widht = widht;
        Height = height;
    }

    public override string ToString()
    {
        return $"{nameof(Widht)}: {Widht}, {nameof(Height)} : {Height}";
    }

    public class Square : Rectangle
    {
        public override int Widht
        {
            set { base.Height = base.Widht = value; }
        }

        public override int Height
        {
            set { base.Widht = base.Height = value; }
        }
    }

    public class Demo
    {
        public static int Area(Rectangle rectangle) => rectangle.Widht * rectangle.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Rectangle square = new Square();
            square.Widht = 4;
           
            Console.WriteLine($"{rc} has area {Area(rc)}");
            Console.WriteLine($"{square} has area {Area(square)}");
        }
    }
}

/*
 * Liskov Substitution Principle (LSP):
 *
 * Bir sınıfın alt sınıfları, üst sınıflarının yerine geçebilmelidir.
 * Yani, bir alt sınıf, üst sınıfın fonksiyonelliğini bozacak şekilde davranmamalıdır.
 * Penguen, kuş sınıfından türemesine rağmen uçma fonksiyonu geçerli olmadığı için LSP ihlali yapar.
 */