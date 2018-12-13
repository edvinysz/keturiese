using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Server.Models;
using Client.Task;
using Server.Observers.Gameplay;
using Server.Decorators;
using Server.AbstractFactory;
using Server.Adapter;
using Server.Iterators;
using Server.Iterators.Block;

namespace GameClient
{
    class Program
    {
        static string serverUrl = "http://localhost:5000/";
        static HttpClient client = new HttpClient();
        static string mediaType = "application/json";
        
        static void Main()
        {
            Console.WriteLine("Web API Client Started!");

            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(serverUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            
            try
            {
                Console.WriteLine("Design pattern implementation:");

                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Implemented patterns: ");
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("1. Singleton pattern");
                Console.WriteLine("2. Factory pattern");
                Console.WriteLine("3. Abstract Factory pattern");
                Console.WriteLine("4. Strategy pattern");
                Console.WriteLine("5. Observer pattern");
                Console.WriteLine("6. Builder pattern");
                Console.WriteLine("7. Prototype pattern");
                Console.WriteLine("8. Decorator pattern");
                Console.WriteLine("9. Adapter pattern");
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("A. Proxy pattern");
                Console.WriteLine("T. Template pattern");
                Console.WriteLine("B. Iterator pattern");

                while (true)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.Write("Choose pattern key: ");
                    ConsoleKey patternKey = Console.ReadKey().Key;
                    Console.WriteLine();

                    switch (patternKey)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Singleton pattern");
                            await executeSingletonPattern();
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("Factory pattern");
                            // executeFactoryPattern();
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Abstract Factory pattern");
                            await executeAbstractFactoryPattern();
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("Strategy pattern");
                            break;
                        case ConsoleKey.D5:
                            Console.WriteLine("Observer pattern");
                            await executeObserverPattern();
                            break;
                        case ConsoleKey.D6:
                            Console.WriteLine("Builder pattern");
                          //  await executeBuilderPattern();
                            break;

                        case ConsoleKey.D7:
                            Console.WriteLine("Prototype pattern");
                            await executePrototypePattern();
                            break;
                        case ConsoleKey.D8:
                            Console.WriteLine("Decorator pattern");
                            await executeDecoratorPattern();
                            break;
                        case ConsoleKey.D9:
                            Console.WriteLine("Adapter pattern");
                            await executeAdapterPattern();
                            break;
                        case ConsoleKey.A:
                            Console.WriteLine("Proxy pattern:");
                            await executeProxyPattern();
                            break;
                        case ConsoleKey.T:
                            Console.WriteLine("Template pattern:");
                            await executeTemplatePattern();
                            break;
                        case ConsoleKey.B:
                            Console.WriteLine("Iterator pattern:");
                            await executeIteratorPattern();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static async Task executeProxyPattern()
        {
            Console.WriteLine("get position X : Y");
            //Position poz = Factory.Get(0);
            PositionProxy proxy = new PositionProxy();
            Console.WriteLine(proxy.getPositionX() + " : " + proxy.getPositionY());
            Console.WriteLine("set position by +25 : +15 = X : Y");
            proxy.setPositionX(35);
            proxy.setPositionY(25);
            Console.WriteLine(proxy.getPositionX() + " : " + proxy.getPositionY());
        }

        static async Task executeAdapterPattern()
        {
            BlockFactory factoryA = new EnemyBlockFactory();
            Block test1 = factoryA.CreateEnemyBlock("Deadly");
            Console.WriteLine($"Id: {test1.Id}\tName: {test1.Name}\tImageId: " + $"{test1.ImageId}\tHeight: " + $"{test1.Height}\tWidth: " + $"{test1.Width}\tDamage: " + $"{test1.Damage}");
            MoveAdapter adapter = new ConcreteAdapter();
            adapter.Move(test1);
            Console.WriteLine("After moving");
            Console.WriteLine($"Id: {test1.Id}\tName: {test1.Name}\tImageId: " + $"{test1.ImageId}\tHeight: " + $"{test1.Height}\tWidth: " + $"{test1.Width}\tDamage: " + $"{test1.Damage}");

        }

        static async Task executeSingletonPattern()
        {
            PlayerTaskSingleton playerTask = PlayerTaskSingleton.getInstance();

            try
            {
                Console.WriteLine("Retrieve all players");

                ICollection<Player> playersList = await playerTask.GetAllPlayerAsync(serverUrl);

                foreach (Player p in playersList)
                {
                    PlayerTaskSingleton.getInstance().ShowPlayer(p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task executeAbstractFactoryPattern()
        {
            BlockTaskAbstractFactory.createBlock();
        }

        static async Task executeObserverPattern()
        {
            Console.WriteLine("Create a few players");

            List<Player> players = new List<Player>();

            players.Add(new Player { Id = 55, Username = "Antanas", DeathCount = 0 });
            players.Add(new Player { Id = 66, Username = "Paulius", DeathCount = 1 });
            players.Add(new Player { Id = 54, Username = "Gabrielius", DeathCount = 1 });

            Console.WriteLine("Initialize observer instance");
            StatusObserver gameplayStatusObserver = new StatusObserver();

            Console.WriteLine("Add players to observer subscribers");
            foreach (Player player in players)
            {
                gameplayStatusObserver.add(player);
            }

            Console.WriteLine("Imitate gameplay status change");
            gameplayStatusObserver.notifyAll("Game finished");
        }

        static async Task executeTemplatePattern()
        {
            Console.WriteLine("Initialize block");
            BlockFactory factory = new EnemyBlockFactory();
            Block test = factory.CreateEnemyBlock("Big");
            Console.WriteLine("Newly created block: " + test.ToString());
            Console.WriteLine("Using template pattern");
            test.createBlockTemplate("Deadly", 66, 66, 25);
            Console.WriteLine("Modified block: " + test.ToString());
        }

        static async Task executePrototypePattern()
        {
            Console.WriteLine("Create prototype");
            Manager gameinfomanager = new Manager();
            GameInfoPrototype gameinfo = new GameInfoPrototype(0, "test1", 0, 0, -1, -1, -1, -1, 0, 0, false, false);
            GameInfoPrototype gameinfo2 = new GameInfoPrototype(0, "test1", 0, 100, 1, 2, 3, 4, 4, 0, false, false);

            //initialize standart
            gameinfomanager["Map1 without players"] = gameinfo;

            //user personalized
            gameinfomanager["Map1 started"] = gameinfo2;

            //cloning
            GameInfoPrototype gameinfo1 = gameinfomanager["Map1 without players"].Clone() as GameInfoPrototype;
        }

        //prototype manager
        class Manager
        {
            private Dictionary<string, GameInfo> _games = new Dictionary<string, GameInfo>();

            //indexer
            public GameInfo this[string key]
            {
                get { return _games[key]; }
                set { _games.Add(key, value); }
            }
        }

        static async Task executeDecoratorPattern()
        {
            Console.WriteLine("Simple block:");
            IBlock block = new Block(1, "Block", 1, 1, 1, 20);
            Console.WriteLine(block);

            Console.WriteLine("Decorated with additional damage:");
            BlockDecorator strongerBlock = new AdditionalDamage(block);
            Console.WriteLine(strongerBlock);

            Console.WriteLine("Decorated with fewer damage:");
            BlockDecorator weakerBlock = new FewerDamage(block);
            Console.WriteLine(weakerBlock);
        }

        static async Task executeIteratorPattern()
        {
            BlockCollection blockCollection = new BlockCollection();

            blockCollection[0] = new Block(1, "Block 1", 0, 0, 0, 0);
            blockCollection[1] = new Block(2, "Block 2", 0, 0, 0, 0);
            blockCollection[2] = new Block(3, "Block 3", 0, 0, 0, 0);
            blockCollection[3] = new Block(4, "Block 4", 0, 0, 0, 0);

            AbstractIterator blockIterator = blockCollection.createIterator();

            object block = blockIterator.first();
            while (block != null)
            {
                Console.WriteLine(block);
                block = blockIterator.next();
            }
        }
    }
}