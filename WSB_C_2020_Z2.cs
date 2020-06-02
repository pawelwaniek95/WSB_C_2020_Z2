using System;

namespace WSB_C_2020_Z2
{
    class WSB_C_2020_Z2
    {
        static void Main(string[] args)
        {
            // Zadanie 5

            // Wysłanie komunikatów do użytkownika
            Console.WriteLine("### Kalkulator ###");

            // Wywołanie klasy kalkulator
            Calculator();

            Console.WriteLine();
            Console.WriteLine("Aby zakończyć wciśnij enter");
            Console.ReadLine();
        }

        static float Calculator()
        {
            Console.Write("Podaj pierwszą liczbę: ");
            int errorFlag = 0;

            // Pobranie danych wejściowych od użytkownika i poprawienie ewentualnego błędu w przecinku, gdy użytkownik dał kropkę zamiast przecinka
            String numberToParse = Console.ReadLine();
            numberToParse = numberToParse.Replace(".", ",");

            // Zmienna przechowująca pierwszą liczbę
            float number1 = 0;

            // Gdy wystąpi bład parsowania, flaga zostanie ustawiona
            if (!float.TryParse(numberToParse, out number1))
            {
                errorFlag = 1; Console.WriteLine("Błąd parsowania pierwszej liczby");

            }

            // Zmienna przechowująca drugą liczbę
            float number2 = 0;

            if (errorFlag == 0)
            {
                Console.Write("Podaj drugą liczbę: ");

                // Ponowne wykorzystanie już utworzonej zmiennej przechowującej dane wejściowe
                numberToParse = Console.ReadLine();
                numberToParse = numberToParse.Replace(".", ",");

                if (errorFlag == 0 && !float.TryParse(numberToParse, out number2))
                {
                    errorFlag = 1;
                    Console.WriteLine("Błąd parsowania drugiej liczby");
                }
            }

            // Zmienna przechowująca decyzję użytkownika
            int decision = 0;

            if (errorFlag == 0)
            {
                Console.WriteLine("Jaką operację chcesz wykonać?");
                Console.WriteLine("1 - dodawanie");
                Console.WriteLine("2 - odejmowanie");
                Console.WriteLine("3 - mnożenie");
                Console.WriteLine("4 - dzielenie");
                Console.Write("Operacja: ");

                if (!int.TryParse(Console.ReadLine(), out decision))
                {
                    errorFlag = 1;
                    Console.WriteLine("Błąd parsowania działania");
                }
            }

            // Linia odstępu
            Console.WriteLine();

            float result = 0;

            if (errorFlag == 0)
            {
                switch (decision)
                {
                    case 1: // Dodawanie
                        Console.WriteLine(number1 + " + " + number2 + " = " + add(number1, number2));
                        break;

                    case 2: // Odejmowanie
                        Console.WriteLine(number1 + " - " + number2 + " = " + subtraction(number1, number2));
                        break;

                    case 3: // Mnożenie
                        Console.WriteLine(number1 + " * " + number2 + " = " + times(number1, number2));
                        break;

                    case 4: // Dzielenie
                        Console.WriteLine(number1 + " / " + number2 + " = " + divide(number1, number2));
                        break;

                    default:
                        Console.WriteLine("Nie podano operacji, chcesz spróbować jeszcze raz?");
                        break;
                }
            }
            return result;
        }

        static float add(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }

        static float subtraction(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }

        static float times(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }

        static float divide(float firstNumber, float secondNumber)
        {
            float result = 0;
            try
            {
                // Jako, że zmienne typu float nie wywołują wyjątku dzielenia przez zero to musimy wymusić ręcznie ten wyjątek, by użyć obsługi wyjątków
                if (secondNumber == 0)
                {
                    throw new DivideByZeroException();
                }

                result = firstNumber / secondNumber;

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Pamiętaj [...] nie dziel przez zero!");
            }
            catch (Exception e)
            {
                // Gdyby wystąpił inny wyjątek, którego nie uwzględniono
                Console.WriteLine("Coś poszło nie tak... Spróbuj jeszcze raz");
            }
            return result;
        }

    }
}
