using System;

namespace ReservationSystem
{
    class AirlineReservationSystem
    {
        static bool[] seats;
        static int firstClass, economy;
        static void Main(string[] args)
        {
            /* (Airline Reservations System) A small airline has just purchased a computer for its new automated
            reservations system. You have been asked to develop the new system. You’re to write an
            app to assign seats on each flight of the airline’s only plane (capacity: 10 seats).
            Display the following alternatives: Please type 1 for First Class and Please type 2 for
            Economy. If the user types 1, your app should assign a seat in the first-class section (seats 1–5). If the
            user types 2, your app should assign a seat in the economy section (seats 6–10).
            Use a one-dimensional array of type bool to represent the seating chart of the plane. Initialize
            all the elements of the array to false to indicate that all the seats are empty. As each seat is
            assigned, set the corresponding element of the array to true to indicate that the seat is no longer
            available.
            Your app should never assign a seat that has already been assigned. When the economy section
            is full, your app should ask the person if it’s acceptable to be placed in the first-class section (and
            vice versa). If yes, make the appropriate seat assignment. If no, display the message "Next flight
            leaves in 3 hours." */

            seats = new bool[11];
            int selectedClass = 0;
                  

            for (int i = 1; i <= 10; i++)
            {
                seats[i] = false;
                Console.WriteLine("Please type 1 for First Class or 2 for Economy Class");
                selectedClass = int.Parse(Console.ReadLine());

                while (selectedClass < 1 || selectedClass > 2)
                {
                    Console.WriteLine("Please only enter 1 or 2");
                    selectedClass = int.Parse(Console.ReadLine());
                }

                if (selectedClass == 1)
                {
                    if (firstClass == 5 && economy < 5)
                    {
                        Console.WriteLine("Sorry, First Class is full. Do you want to get a ticket for economy class? Y/N");
                        if ((Console.ReadLine().Equals("N")) || (Console.ReadLine().Equals("n")))
                        {
                            Console.WriteLine("Next flight leaves in 3 hours");
                            i--;
                        }
                        else
                        {
                            EconomyClass();
                        }
                    }
                    else if (firstClass < 5)
                    {
                        FirstClass();
                    }
                }
                else if (selectedClass == 2)
                {
                    if (economy == 5 && firstClass < 5)
                    {
                        Console.WriteLine("Sorry, Economy Class is full. Do you want to get a ticket for first class? Y/N");
                        if ((Console.ReadLine().Equals("N")) || (Console.ReadLine().Equals("n")))
                        {
                            Console.WriteLine("Next flight leaves in 3 hours");
                            i--;
                        }
                        else
                        {
                            FirstClass();
                        }
                    }
                    else
                    {
                        EconomyClass();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Sorry, The plane is full. Next fight leaves in 3 hours.");
            Console.ReadLine();

        }// end Main

        static void FirstClass()
        {
            bool correspondingSeats = false;
            Random rand = new Random();
            int index = 0;

            //Assign free seat in frst class
            while (!correspondingSeats)
            {
                correspondingSeats = true;
                index = rand.Next(1, 6);
                if (seats[index] == true)
                {
                    correspondingSeats = false;
                }
            }
            seats[index] = true;
            firstClass++;
            Console.WriteLine("Assigned seat {0:N0}", index);

        }// end First Class

        static void EconomyClass()
        {
            bool correspondingSeats = false;
            Random rand = new Random();
            int index = 0;

            //Assign free seat in economy
            while (!correspondingSeats)
            {
                correspondingSeats = true;
                index = rand.Next(6, 11);
                if (seats[index] == true)
                {
                    correspondingSeats = false;
                }
            }
            seats[index] = true;
            economy++;
            Console.WriteLine("Assigned seat {0:N0}", index);

        }// end Economy Class
    }
}
