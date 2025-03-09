using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string input;
        do
        {
            Console.WriteLine("Digite o número do cartão de crédito (ou 'quit!' para sair):");
            input = Console.ReadLine()?.Replace(" ", "").Replace("-", "");

            if (input?.ToLower() == "quit!")
            {
                break;
            }

            if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d+$"))
            {
                Console.WriteLine("Número de cartão inválido. Tente novamente.\n");
                continue;
            }

            string bandeira = IdentificarBandeira(input);

            if (bandeira != null)
            {
                Console.WriteLine($"Bandeira do cartão: {bandeira}\n");
            }
            else
            {
                Console.WriteLine("Bandeira não identificada.\n");
            }

        } while (true);

        Console.WriteLine("Programa encerrado. Até mais!");
    }

    static string IdentificarBandeira(string numeroCartao)
    {
        if (IsMasterCard(numeroCartao))
        {
            return "MasterCard";
        }
        else if (IsVisa(numeroCartao))
        {
            return "VISA";
        }
        else if (IsAmericanExpress(numeroCartao))
        {
            return "American Express";
        }
        else if (IsDinersClub(numeroCartao))
        {
            return "Diners Club";
        }
        else if (IsDiscover(numeroCartao))
        {
            return "Discover";
        }
        else if (IsEnRoute(numeroCartao))
        {
            return "EnRoute";
        }
        else if (IsJCB(numeroCartao))
        {
            return "JCB";
        }
        else if (IsLaser(numeroCartao))
        {
            return "Laser";
        }
        else if (IsMaestro(numeroCartao))
        {
            return "Maestro";
        }
        else if (IsVisaElectron(numeroCartao))
        {
            return "Visa Electron";
        }
        else if (IsHiperCard(numeroCartao))
        {
            return "HiperCard";
        }
        else if (IsAura(numeroCartao))
        {
            return "Aura";
        }
        else if (IsVoyager(numeroCartao))
        {
            return "Voyager";
        }

        return null;
    }

    static bool IsMasterCard(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^5[1-5]\d{14}$");
    }

    static bool IsVisa(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^4\d{12}(\d{3})?$");
    }

    static bool IsAmericanExpress(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^3[47]\d{13}$");
    }

    static bool IsDinersClub(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^3(0[0-5]|[68]\d)\d{11}$");
    }

    static bool IsDiscover(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^6(011|5\d{2})\d{12}$");
    }

    static bool IsEnRoute(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^(2014|2149)\d{11}$");
    }

    static bool IsJCB(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^35\d{14}$");
    }

    static bool IsLaser(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^(6304|6706|6771|6709)\d{12}(\d{2,3})?$");
    }

    static bool IsMaestro(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^(5018|5020|5038|5612|5893|6304|6759|6761|6762|6763|0604|6390)\d{12}$");
    }

    static bool IsVisaElectron(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^(4026|417500|4508|4844|4913|4917)\d{10}$");
    }

    static bool IsHiperCard(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^(606282|3841)\d{10}$");
    }

    static bool IsAura(string numeroCartao)
    {
        return Regex.IsMatch(numeroCartao, @"^50\d{14}$");
    }

    static bool IsVoyager(string numeroCartao)
    {
        // Regex ajustada para aceitar 15 dígitos começando com "8699"
        return Regex.IsMatch(numeroCartao, @"^8699\d{11}$");
    }
}