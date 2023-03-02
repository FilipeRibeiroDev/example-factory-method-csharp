using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace factory_method
{
    internal class Factory
    {
        public static void ObterSomDeAnimal(string animal)
        {
            Animal.Get(animal).Som();
            //if (animal == "Cachorro")
            //{
            //    Console.WriteLine("Au! au!");
            //}
            //else if (animal == "Gato")
            //{
            //    Console.WriteLine("Miau");
            //}
            //else if (animal == "Vaca")
            //{
            //    Console.WriteLine("Muuuuu!");
            //}
            //else if (animal == "Galinha")
            //{
            //    Console.WriteLine("Carococó");
            //}
        }
    }

    internal abstract class Animal
    {
        public static Animal Get(string animal)
        {
            var instance = Assembly.GetAssembly(typeof(Animal)).GetTypes()
                             .Where(myType => myType.IsClass && !myType.IsAbstract 
                                    && myType.IsSubclassOf(typeof(Animal)))
                            .FirstOrDefault(x => x.Name.ToLowerInvariant()
                                                .Equals(animal.ToLowerInvariant()));

            if (instance == null) throw new ArgumentNullException("Not found");

            return (Animal)Activator.CreateInstance(instance);
        }

        public abstract void Som();
    }

    internal class Gato : Animal
    {
        public override void Som()
        {
            Console.WriteLine("Miau");
        }
    }

    internal class Cachorro : Animal
    {
        public override void Som()
        {
            Console.WriteLine("Au Au");
        }
    }
}
