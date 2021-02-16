using System;

public static class CookieBakery
{
    public static void Main()
    {
        // variable/constant declarations
        int cookies = 0,
        	halfTotalStringLength;
        double total,
            cookieCost;
        string customerName,
            shortCustomerName;
        const double TAX_RATE = 0.13,
            COVER_CHARGE = 0.25;

        // Display a shop welcome message
        Console.WriteLine("Welcome to Hurley's bakery!");
        
        // while loop to take in the cookie order
        // will loop until the user has entered a positive integer
        while (cookies <= 0)
        {
            // try statement to catch invalid inputs
            try
            {
                // prompt and take in customer's cookie order
                Console.WriteLine("\nHow many cookies would you like to order?");
                cookies = Convert.ToInt32(Console.ReadLine());

                // catch the user ordering 0 cookies and display an error message
                if (cookies == 0)
                    Console.WriteLine("You can't order zero cookies, you silly goose! " +
                        "Please order at least 1 cookie.");

                // catch the user ordering a negative amount of cookies and display an error
                else if (cookies < 0)
                    Console.WriteLine("You can't order negative cookies, you absolute " +
                        "rascal. Please order at least 1 cookie.");
            }

            // catch users entering non-numerical characters or floats
            catch (FormatException)
            {
                Console.WriteLine("Error: please input a positive integer for your order!");
            }
            // catch users exeeding int limit
            catch (SystemException)
            {
                Console.WriteLine("ERROR: WAY TOO MANY COOKIES");
            }

        // end of while loop
        }

        // from here we can assume 'cookies' is a positive integer

        // prompt user and take in customer name
        Console.WriteLine("\nCould we get a last name for this order?");
        customerName = Console.ReadLine();

        // determine what price category our order falls 
        if (cookies <= 3)
            cookieCost = 2;
        else if (cookies < 9)
            cookieCost = 1.75;
        else if (cookies <= 15)
            cookieCost = 1.5;
        else
            cookieCost = 1;

        // calculate order total
        // if the user orders < 12 cookies we apply tax to the order
        if (cookies < 12)
            total = ((cookies * cookieCost) + COVER_CHARGE) * (1 + TAX_RATE);
        else
            total = (cookies * cookieCost) + COVER_CHARGE;

        // display order summary table
        Console.WriteLine("\n -----------------------------------------------");
        Console.WriteLine("|                 Order Summary                 |");
        Console.WriteLine("|-----------------------------------------------|");
        Console.WriteLine("| Customer Name | # of cookies  | $ per cookie  |");
        Console.WriteLine("|---------------|---------------|---------------|");

        // if the customer name is too long this will trim the name in order to fit inside
        // the order summary and indicate it was shortened
        if (customerName.Length > 13)
        {
            shortCustomerName = customerName.Remove(10) + "...";
            Console.WriteLine("| {0,-13} | {1,-13} | {2, -13} |",
                shortCustomerName, cookies, cookieCost);
        }
        else
            Console.WriteLine("| {0,-13} | {1,-13} | {2, -13} |",
            	customerName, cookies, cookieCost);

        // display order total box
        Console.WriteLine("|-----------------------------------------------|");
        Console.WriteLine("|                  Order Total                  |");
        Console.WriteLine("|-----------------------------------------------|");

        // this should center the order total within the order total 'box' by finding the
        // length of the final total string after being converted to it's currency format
        //  and dividing it by 2. this is used to proplerly modify the alignment argument
        halfTotalStringLength = (String.Format("{0:C}", total).Length) / 2;
        Console.WriteLine("| {0," + (23 + halfTotalStringLength) + ":C} " +
        	"{1," + (23 - halfTotalStringLength) + "}",
            total, "|");

        // finish the order summary box
        Console.WriteLine(" -----------------------------------------------");

        // Holds the output window
        Console.ReadLine();
    }
}