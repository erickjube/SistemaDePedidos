using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDePedidos.Domain.ValueObjects;

public class CPF
{
    public string Value { get; }

    public CPF(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("CPF não pode estar vazio.", nameof(value));
        if (!ValidateCPF(value)) throw new ArgumentException("CPF inválido.", nameof(value));
        Value = value;
    }

    private static bool ValidateCPF(string cpf)
    {
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11) return false;

        if (cpf.Distinct().Count() == 1) return false;

        int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf[..9];
        int sum = 0;

        for (int i = 0; i < 9; i++) sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

        int Remainder = sum % 11;
        Remainder = Remainder < 2 ? 0 : 11 - Remainder;

        string digit = Remainder.ToString();
        tempCpf += digit;
        sum = 0;

        for (int i = 0; i < 10; i++) sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

        Remainder = sum % 11;
        Remainder = Remainder < 2 ? 0 : 11 - Remainder;

        digit += Remainder.ToString();

        return cpf.EndsWith(digit);
    }

}
