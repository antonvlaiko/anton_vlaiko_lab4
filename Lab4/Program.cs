using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4;

namespace Lab4  {

    interface ICollectableForestElement : IForestElement {
        void Dogrose();
    }
    interface ICutDown {
        void CutDown();
    }
    interface IForestElement {
    }
    interface IPlant {
        void Plant();
    }

    class Forest {
        List<IForestElement> trees = new List<IForestElement>();

        public void Plant(IForestElement tree) {
            trees.Add(tree);
        }
        public void CutDown(IForestElement tree) {
            trees.Remove(tree);
        }
        public int ElementsCount() {
            return trees.Count;
        }
    }
    class Bush : ICollectableForestElement, IPlant {
        public void Plant() => Console.WriteLine("Вiтаю, Ви посадили кущ! ");

        List<ICollectableForestElement> berry = new List<ICollectableForestElement>();
        public void Plant(ICollectableForestElement berries)
        {
            berry.Add(berries);
        }

        public void PickUp(ICollectableForestElement berries)
        {
            berry.Remove(berries);
        }
        public void PutIn()
        {
            throw new NotImplementedException();
        }
        public int ElCount()
        {
            return berry.Count;
        }
        public void Brier()
        {
            throw new NotImplementedException();
        }

        public void Dogrose()
        {
            throw new NotImplementedException();
        }
    }

    class Tree : IForestElement, ICutDown, IPlant {
        public void Plant() => Console.WriteLine("Вiтаю, Ви посадили дерево! ");
        public void CutDown() => Console.WriteLine("Журбинка, Ви зрубали дерево! ");
    }
    class ChristmasTree : IForestElement, IPlant {
        public void Plant() => Console.WriteLine("Вiтаю, Ви посадили ялинку! ");
    }


    class Berries : ICollectableForestElement {
        public void Dogrose() => Console.WriteLine("Ви зiбрали ягоди!");
    }
    class Brier : ICollectableForestElement {
        public void Dogrose() => Console.WriteLine("Ви зiбрали малину! ");
    }

    class Program {
        static void Main(string[] args) {
            var forest = new Forest();
            var bush = new Bush();
            var berries = new Berries();
            var Brier = new Brier();
            var christmasTree = new ChristmasTree();
            var tree = new Tree();

            forest.Plant(tree);
            ((IPlant)tree).Plant();

            forest.Plant(christmasTree);
            ((IPlant)christmasTree).Plant();

            forest.Plant(bush);
            ((IPlant)bush).Plant();

            Console.WriteLine("У лiсi є " + forest.ElementsCount() + " дерева");

            forest.CutDown(tree);
            ((ICutDown)tree).CutDown();

            Console.WriteLine("У лiсi тепер стало " + forest.ElementsCount() + " дерева");

            bush.Plant(berries);
            bush.Plant(Brier);
            bush.Plant(berries);
            bush.Plant(berries);
            bush.Plant(berries);

            Console.WriteLine("Кущ має " + bush.ElCount() + " ягiд");

            bush.PickUp(berries);
            bush.PickUp(berries);
            bush.PickUp(berries);
            bush.PickUp(berries);
            bush.PickUp(Brier);
            ((ICollectableForestElement)Brier).Dogrose();

            Console.WriteLine("Кущ тепер має " + bush.ElCount() + " ягiд");

        }
    }
}
