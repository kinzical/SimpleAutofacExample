using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace AutoFacExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StackCreation>().As<IStackCreation>();
            builder.RegisterType<StackOperations>().As<IStackOperations>();

            var container = builder.Build();
            container.Resolve<IStackCreation>().creation();
            container.Resolve<IStackOperations>().Operations();
        }
    }
    public interface IStackCreation
    {
        void creation();
    }
    public interface IStackOperations
    {
        void Operations();
    }
    public class StackCreation : IStackCreation
    {
        public void creation()
        {
            Stack<int> s = new Stack<int>(5);
        }
    }
    public class StackOperations : IStackOperations
    {
        Stack<int> s = new Stack<int>(5);
        public void Operations()
        {
            s.Push(1);
            s.Push(2);
            s.Push(3);
            Console.WriteLine("Popped element is {0}", s.Pop());
            Console.WriteLine("Last element is {0}", s.Peek());
            Console.WriteLine("Elements of stack are:");
            int[] arr = s.ToArray();
            foreach (Object str in arr)
            {
                Console.WriteLine(str);
            }
        }
    }
    public class stack
    {
        IStackCreation stackCreation;
        IStackOperations stackOperations;
        public stack(IStackCreation sc, IStackOperations so)
        {
            stackCreation = sc;
            stackOperations = so;
        }
        public void execute()
        {
            stackCreation.creation();
            stackOperations.Operations();
        }
    }
}

