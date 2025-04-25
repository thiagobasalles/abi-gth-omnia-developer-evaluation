using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public record NameVo
    {
        public string Firstname { get; }
        public string Lastname { get; }

        public NameVo(string firstname, string lastname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentException("Firstname is required.");

            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentException("Lastname is required.");

            Firstname = firstname;
            Lastname = lastname;
        }

        public override string ToString() => $"{Firstname} {Lastname}";

    }
}
