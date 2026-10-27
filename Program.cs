while (true)
{
    Console.WriteLine("Welcome to the Decimal and Binary Converter!");
    Console.WriteLine("Press 1 to convert a decimal number to binary.");
    Console.WriteLine("Press 2 to convert a binary number to decimal.");
    string? choice = Console.ReadLine();
    if (choice == "1")
    {
        while (true)
        {
            Console.Write("Enter a decimal number sperate by dots: ");
            string completeBinaryValue = "";
            string?[] octets = Console.ReadLine().Split('.');
            foreach (string? octet in octets)
            {
                if (!double.TryParse(octet, out double decimalOctet))
                {
                    Console.WriteLine($"Invalid input '{octet}'. Please enter valid decimal numbers.");
                    completeBinaryValue += "Break";
                    break;
                }
                if (decimalOctet < 0)
                {
                    Console.WriteLine($"Invalid input '{octet}'. Please enter decimal numbers over 0.");
                    completeBinaryValue += "Break";
                    break;
                }
                string binaryValue = "";
                while (decimalOctet > 0)
                {
                    double remainder = decimalOctet % 2;
                    binaryValue += remainder;
                    decimalOctet /= 2;
                    decimalOctet = Math.Floor(decimalOctet); // Use Math.Floor to ensure we get the integer part
                }
                binaryValue = binaryValue.PadRight(8, '0'); // Pad with leading zeros to make it 8 bits

                completeBinaryValue += new string(binaryValue.Reverse().ToArray());
                completeBinaryValue += ".";
            }
            if (completeBinaryValue.Contains("Break"))
            {
                continue;
            }
            Console.WriteLine("Complete binary representation: " + completeBinaryValue.TrimEnd('.'));
            break;  
        }
    }
    if (choice == "2")
    {
        while (true)
        {
            Console.Write("Enter a binary number sperate by dots: ");
            string completeBinaryValue = "";
            string? binaryValue = Console.ReadLine();
            if (binaryValue.Any(c => c != '0' && c != '1' && c != '.'))
            {
                Console.WriteLine("Invalid input. Please enter a valid binary number.");
                continue;
            }
            string?[] octets = binaryValue.Split('.');
            foreach (string? octet in octets)
            {
                if (!double.TryParse(octet, out double decimalvalue))
                {
                    Console.WriteLine($"Invalid input '{octet}'. Please enter valid binary numbers.");
                    completeBinaryValue += "Break";
                    break;
                }
                double decimalValue = 0;
                double power = 1;
                while (decimalvalue > 0)
                {
                    double remainder = decimalvalue % 10;
                    decimalValue += (double)remainder * power;
                    power *= 2;
                    decimalvalue /= 10;
                    decimalvalue = Math.Floor(decimalvalue);
                }
                completeBinaryValue += decimalValue + ".";
            }
            if (completeBinaryValue.Contains("Break"))
            {
                continue;
            }
            Console.WriteLine("Complete decimal representation: " + completeBinaryValue.TrimEnd('.'));
            break;
        }
        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("Invalid choice. Please select either 1 or 2.");
            continue;
        }
    }
}