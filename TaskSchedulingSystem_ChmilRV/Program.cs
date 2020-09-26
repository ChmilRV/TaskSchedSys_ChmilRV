using System;
using static System.Console;
using System.Collections.Generic;
/*Реализуйте с использованием паттернов проектирования простейшую систему планирования задач.
Должна быть возможность создания списка дел, установки приоритетов,
установки дат выполнения, удаление и изменения дел. Каждому делу можно установить тег.
Список дел можно загружать и сохранять в файл.
Необходимо реализовать возможность поиска конкретного дела.
Критерии поиска: по датам, по тегам, по приоритету и так далее.*/
namespace TaskSchedulingSystem_ChmilRV
{
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }
    public class ConcreteBuilder : IBuilder
    {
        private Product product = new Product();
        public ConcreteBuilder() { Reset(); }
        public void Reset() { product = new Product(); }
        public void BuildPartA() { product.Add("PartA1"); }
        public void BuildPartB() { product.Add("PartB1"); }
        public void BuildPartC() { product.Add("PartC1"); }
        public Product GetProduct()
        {
            Product result = product;
            Reset();
            return result;
        }
    }
    public class Product
    {
        private List<object> parts = new List<object>();
        public void Add(string part) { parts.Add(part); }
        public string ListParts()
        {
            string str = string.Empty;
            for (int i = 0; i < parts.Count; i++) { str += parts[i] + ", "; }
            str = str.Remove(str.Length - 2);
            return "Product parts: " + str + "\n";
        }
    }
    public class Director
    {
        private IBuilder builder;
        public IBuilder Builder { set { builder = value; } }
        public void buildMinimalViableProduct() { builder.BuildPartC(); }
        public void buildFullFeaturedProduct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // порождающий - строитель
            // структурный - компоновщик
            Director director = new Director();
            ConcreteBuilder builder = new ConcreteBuilder();
            director.Builder = builder;
            WriteLine("Standard basic product:");
            director.buildMinimalViableProduct();
            WriteLine(builder.GetProduct().ListParts());
            WriteLine("Standard full featured product:");
            director.buildFullFeaturedProduct();
            WriteLine(builder.GetProduct().ListParts());
            WriteLine("Custom product:");
            builder.BuildPartA();
            builder.BuildPartC();
            builder.BuildPartB();
            builder.BuildPartA();
            builder.BuildPartC();
            builder.BuildPartA();
            Write(builder.GetProduct().ListParts());
            ReadKey();
        }
    }
}
