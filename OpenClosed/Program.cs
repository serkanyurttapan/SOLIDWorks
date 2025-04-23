// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var apple = new Product("Apple", Color.Green, Size.Small);
var phone = new Product("Phone", Color.Red, Size.Medium);
var tree = new Product("Tree", Color.Green, Size.Large);

Product[] products = { apple, phone, tree };
var pf = new ProductFilter();
Console.WriteLine(pf.FilterByColor(products, Color.Green));

var spec = new BetterFilter();
spec.Filter(products, new ColorSpecification(Color.Blue));
 
public class Product
{
    public string Name { get; set; }
    public Color Color { get; set; }
    public Size Size { get; set; }

    public Product(string name,Color color,Size size)
    {
        Name = name;
        Color = color;
        Size = size;
    }
}

public interface ISpecification<T>
{
    bool IsSatisfied(T t);
}

public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
}

public class ColorSpecification : ISpecification<Product>
{
    private Color _color;

    public ColorSpecification(Color color)
    {
        _color = color;
    }
    public bool IsSatisfied(Product t)
    {
        return t.Color == _color; 
    }
}

public class BetterFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
    {
        foreach (var i in items)
        {
            if (specification.IsSatisfied(i))
            {
                yield return i;
            }
        }
    }
}







public class ProductFilter
{
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        foreach (var p in products)
        {
            if (p.Size.Equals(size))
                yield return p;
        }
    }
    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
        foreach (var p in products)
        {
            if (p.Color.Equals(color))
                yield return p;
        }
    }
    public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products,Size size, Color color)
    {
        foreach (var p in products)
        {
            if (p.Size.Equals(size) && p.Color.Equals(color))
                yield return p;
        }
    }
}






public enum Color {
Red,Blue,Green
}

public enum Size
{
    Small,Medium,Large,Yuge
}


/*
 * Open/Closed Principle (OCP):
 *
 * Bir sınıf, genişletilebilir olmalı ancak değiştirilemez olmalıdır. Yeni özellikler eklemek için mevcut sınıfları değiştirmemeliyiz.
 * Ödeme işlemlerinde her yeni ödeme yöntemi için var olan sınıfları değiştirmek yerine, yeni sınıflar ekleriz.
 */