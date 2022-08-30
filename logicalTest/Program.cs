using System;
using logicalTest.Classes;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome!");

        int networkSize = ReadInt("Please inform the nodes quantity for the network:");
        Network network = new Network(networkSize);

        do
        {
            Console.WriteLine("- Digit 1 to create a new connection between two nodes");
            Console.WriteLine("- Digit 2 to check if a connections exists between two nodes");
            Console.WriteLine("- Digit 3 to exit.");
            int option = ReadInt("");
            Console.Clear();

            switch (option)
            {
                case 1:
                    int firstNode = ReadInt("Please inform the origin node:");
                    Console.Clear();
                    int secondNode = ReadInt("Please inform the destination node:");
                    Console.Clear();
                    network.connect(firstNode, secondNode);
                    break;
                case 2:
                    int firstNodeQuery = ReadInt("Please inform the origin node:");
                    Console.Clear();
                    int secondNodeQuery = ReadInt("Please inform the destination node:");
                    Console.Clear();

                    if (network.query(firstNodeQuery, secondNodeQuery))
                    {
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("Connection found between node " + firstNodeQuery + " and " + secondNodeQuery);
                        Console.WriteLine("--------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("Connection not found between node " + firstNodeQuery + " and " + secondNodeQuery);
                        Console.WriteLine("--------------------------------------");
                    }

                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine("--------------------------------------");
                    break;
            }
        } while (true);
    }

    private static int ReadInt(string message)
    {
        Console.WriteLine(message);
        var response = Console.ReadLine();

        if (int.TryParse(response, out int integer))
        {
            return integer;
        }
        else
        {
            Console.Clear();
            Console.WriteLine(response + " is not a valid integer");
            Console.WriteLine("Please inform the nodes quantity for the network:");
            return ReadInt(message);
        }
    }
}